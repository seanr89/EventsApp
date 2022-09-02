
using EventsAPI.Services;
using EventsAPI.Services.Interfaces;

namespace EventsAPI.Extensions;

public static class DependencyInjection
{
    /// <summary>
    /// Add Application DepdendencyInjection
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IEventService, EventService>();
        services.AddTransient<IEventTypeService, EventTypeService>();
        services.AddTransient<IAttendeeService, AttendeeService>();
        return services;
    }
}