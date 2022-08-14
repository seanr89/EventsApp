using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using EventsAPI.Context;
using EventsAPI.Extensions;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using EventsAPI.HealthChecks;
using EventsAPI.Models.Settings;
using Microsoft.Extensions.Logging.ApplicationInsights;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .AddEnvironmentVariables()
                            .Build();

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program)); 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<PostgreSQLSettings>(
                builder.Configuration.GetSection("PostgreSQL"));

// Connect to PostgreSQL Database
var connectionString = builder.Configuration["PostgreSQL:ConnectionString"];
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(connectionString));


builder.Services.AddHealthChecks()
    .AddCheck<SampleHealthCheck>("Sample", failureStatus: HealthStatus.Degraded, tags: new[] { "sample" })
    .AddCheck<DBHealthCheck>("Db")
    .AddNpgSql(connectionString);
    
builder.Services.AddHealthChecksUI(setup => 
    setup.DisableDatabaseMigrations()
    .SetEvaluationTimeInSeconds(30)
    // Set the maximum history entries by endpoint that will be served by the UI api middleware
    .MaximumHistoryEntriesPerEndpoint(25))
    .AddInMemoryStorage();

// The following line enables Application Insights telemetry collection.
builder.Services.AddApplicationInsightsTelemetry();

//Service DI work
builder.Services.AddApplication();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

if(!app.Environment.IsDevelopment()){
    app.UseHttpsRedirection();
}

app.MapHealthChecks("/healthcheck", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.MapHealthChecksUI(config => config.UIPath = "/hc-ui");

app.MapControllers();

ServiceExtensions.RunDBMigration(builder.Services);

app.Run();
