
using EventsAPI.DTOs;
using EventsAPI.Models;

namespace EventsAPI.Services.Interfaces;

public interface IAttendeeService
{
    Task<IEnumerable<Attendee>> GetAllAttendees();

    Task<Attendee> GetAttendeeById(Guid id);

    Task<bool> SaveAttendee(CreateAttendeeDTO attendeeDTO);
}