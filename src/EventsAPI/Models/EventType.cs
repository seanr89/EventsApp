using System.ComponentModel.DataAnnotations;

namespace EventsAPI.Models
{
    public class EventType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public EventType(string name, bool active)
        {
            Name = name;
            Active = active;
        }
    }
}