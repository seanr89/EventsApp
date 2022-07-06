using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using EventsAPI.Context;
using EventsAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connect to PostgreSQL Database
var connectionString = builder.Configuration["PostgreSQL:ConnectionString"];
Console.WriteLine(connectionString);
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddHealthChecks().AddNpgSql(connectionString);
builder.Services.AddHealthChecksUI(setup => 
    setup.DisableDatabaseMigrations()
    // Set the maximum history entries by endpoint that will be served by the UI api middleware
    .MaximumHistoryEntriesPerEndpoint(50))
    .AddInMemoryStorage();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if(!app.Environment.IsDevelopment()){
    app.UseHttpsRedirection();
    //app.UseAuthorization();
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
