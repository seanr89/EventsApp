

using EventsAPI.Models;

namespace EventsAPI.Services.Interfaces;

public interface IEventService
{
    Task<IEnumerable<Event>> GetAllEvents();

    Task<Event> GetEventById();

    Task<IEnumerable<Event>> GetEventsForDate(DateOnly date);
}