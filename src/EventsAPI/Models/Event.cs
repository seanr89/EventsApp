namespace EventsAPI.Models;

public class Event
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public bool Private { get; set; }
    public EventType Type { get; set; }

    public Event()
    {
        
    }
}