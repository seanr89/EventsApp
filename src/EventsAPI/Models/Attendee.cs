
using System.ComponentModel.DataAnnotations;

namespace EventsAPI.Models;

/// <summary>
/// An idividual person attending for an event
/// </summary>
public record Attendee
{
    [Key]
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
}