
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
    /// <summary>
    /// Unique ID of the event for AutoMapper purposes
    /// </summary>
    /// <value></value>
    public Guid AttendedEventId { get; set; }
    public Event AttendedEvent { get; set; }

    public override string ToString()
    {
        return $"Attendee Id: {Id} for Name: {Name}";
    }
}