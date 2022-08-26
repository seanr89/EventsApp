using EventsAPI.Models;

namespace EventsAPI.Services.Interfaces;

public interface IEventTypeService
{
    Task<IEnumerable<EventType>> GetAllEventTypes();

    Task<EventType> GetEventTypeById(int id);
    Task<bool> SaveEventType(EventType type);
}