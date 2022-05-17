using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
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

builder.Services.AddHealthChecks();//.AddNpgSql(connectionString);


var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
//}

if(!app.Environment.IsDevelopment()){
    //app.UseHttpsRedirection();
    //app.UseAuthorization();
}
//app.MapGet("/", () => "Hello World!");
app.MapHealthChecks("/healthcheck", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
//app.MapHealthChecksUI(config => config.UIPath = "/hc-ui");

app.MapControllers();

//ServiceExtensions.RunDBMigration(builder.Services);

app.Run();
