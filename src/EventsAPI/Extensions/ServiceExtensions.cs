using EventsAPI.Context;
using EventsAPI.Context.Seeding;
using EventsAPI.Models.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EventsAPI.Extensions;

public static class ServiceExtensions
{
    /// <summary>
    /// Setup EFCore DB and Seed any data if necessary
    /// </summary>
    /// <param name="services"></param>
    public static void RunDBMigration(IServiceCollection services)
    {
        try{
            var provider = services.BuildServiceProvider();
            var context = provider.GetRequiredService<ApplicationContext>();
            var opt = provider.GetRequiredService<IOptions<PostgreSQLSettings>>().Value;
    
            if(opt.Migrate)
                context.Database.Migrate();
            
            if(opt.SeedData)
                DataSeeding.TrySeedData(context).Wait();
        }
        catch(Exception e)
        {
            Console.WriteLine($"Exception caught: {e.Message}");
        }
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
