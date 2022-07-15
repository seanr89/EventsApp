

using EventsAPI.Context;
using EventsAPI.Models;
using EventsAPI.Services.Interfaces;

namespace EventsAPI.Services;

/// <summary>
/// new plan for a dedicated service to move events db work away from controller!
/// </summary>
public class EventService : IEventService
{
    private readonly ApplicationContext _context;
    public EventService(ApplicationContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<Event>> GetAllEvents()
    {
        throw new NotImplementedException();
    }

    public Task<Event> GetEventById()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Event>> GetEventsForDate(DateOnly date)
    {
        throw new NotImplementedException();
    }
}