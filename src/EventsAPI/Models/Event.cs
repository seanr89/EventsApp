using System.ComponentModel.DataAnnotations;

namespace EventsAPI.Models;

/// <summary>
/// Basic single event model
/// </summary>
public class Event
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public bool Private { get; set; }
    public EventType Type { get; set; }

    public Event()
    {
        
    }

    public Event(string name)
    {
        Name = name;
    }
}