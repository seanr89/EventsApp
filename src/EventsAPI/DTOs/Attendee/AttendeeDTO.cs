
namespace EventsAPI.DTOs;

/// <summary>
/// basic/simple attendee record
/// </summary>
public class AttendeeDTO
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }

}