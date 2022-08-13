using EventsAPI.Models;

namespace EventsAPI.Services.Interfaces;

public interface IEventService
{
    Task<IEnumerable<Event>> GetAllEvents();

    Task<Event> GetEventById(Guid id);

    Task<IEnumerable<Event>> GetEventsForDate(DateOnly date);

    Task<bool> SaveEvent(Event evnt);
}