
namespace EventsAPI.DTOs;

public class CreateAttendeeDTO
{
    public string Email { get; set; }
    public string Name { get; set; }
    public Guid AttendedEventId { get; set; }
}