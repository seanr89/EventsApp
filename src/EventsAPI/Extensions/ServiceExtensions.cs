using EventsAPI.Context;
using EventsAPI.Context.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventsAPI.Extensions;

    public static class ServiceExtensions
    {
        /// <summary>
        /// Setup EFCore DB and Seed any data if necessary
        /// </summary>
        /// <param name="services"></param>
        public static void RunDBMigration(IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();
        var context = provider.GetRequiredService<ApplicationContext>();
        context.Database.Migrate();
        DataSeeding.TrySeedData(context).Wait();

    }

    /// <summary>
    /// Configuration and setup for CORS settings
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void ConfigureCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                    });
            });
        }
    }
