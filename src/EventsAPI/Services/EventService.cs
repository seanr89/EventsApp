

using EventsAPI.Models;
using EventsAPI.Services.Interfaces;

namespace EventsAPI.Services;

public class EventService : IEventService
{
    public EventService()
    {
        
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