
using EventsAPI.Context;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace EventsAPI.HealthChecks;

public class DBHealthCheck : IHealthCheck
{
    public IServiceProvider _serviceProvider;

    public DBHealthCheck(IServiceProvider serviceProvider)
    {
        _serviceProvider=serviceProvider;
    }

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
     CancellationToken cancellationToken = default)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

            if (dbContext.Database.CanConnect())
            {
                return Task.FromResult(
                HealthCheckResult.Healthy("A healthy DB Connection."));
            }
            return Task.FromResult(
            new HealthCheckResult(
                context.Registration.FailureStatus, "An unhealthy DB Connection."));
        }
    }
}