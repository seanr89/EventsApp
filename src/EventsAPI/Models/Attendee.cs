
using System.ComponentModel.DataAnnotations;

namespace EventsAPI.Models;

/// <summary>
/// An individual attending an event
/// </summary>
public record Attendee
{
    [Key]
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public Guid AttendedEventId { get; set; }
    public Event AttendedEvent { get; set; }

    public Attendee()
    {
        AttendedEvent = new Event();
    }
}