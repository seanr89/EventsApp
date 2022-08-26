using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace EventsAPI.Models;

/// <summary>
/// A single event to be recorded and managed
/// </summary>
public class Event : AuditableEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    /// <summary>
    /// Duration of event in minutes
    /// </summary>
    /// <value></value>
    public int Duration { get; set; }
    /// <summary>
    /// Basic string representation of the event location
    /// </summary>
    /// <value></value>
    public string Location { get; set; }
    /// <summary>
    /// Controls if the event should be visible or not to all
    /// </summary>
    /// <value></value>
    public bool Private { get; set; }
    /// <summary>
    /// Basic information to control different types of events
    /// </summary>
    /// <value></value>
    public EventType Type { get; set; }
    /// <summary>
    /// Name/Email of the person who created the event!
    /// </summary>
    /// <value></value>
    public string Creator { get; set; }
    /// <summary>
    /// TODO
    /// </summary>
    /// <value></value>
    public ICollection<Attendee> Attendees { get; set; }

    public Event()
    {
        
    }

    public Event(string name, DateTime date, int duration, string location, bool privateEvent)
    {
        this.Name = name;
        this.Date = date;
        this.Duration = duration;
        this.Location = location;
        this.Private = privateEvent;
    }

    public override string ToString()
    {
        return $"Event Id: {Id} for Name: {Name}";
    }
}