
namespace EventsAPI.DTOs;

public class EventDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public int Duration { get; set; }
    public string Location { get; set; }
    public string URL { get; set; }
    public bool Private { get; set; }
}