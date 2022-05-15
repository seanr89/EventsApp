using System.ComponentModel.DataAnnotations;

namespace EventsAPI.Models
{
    /// <summary>
    /// Long term plan to have an array or event types to control other selection items
    /// </summary>
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