using System.ComponentModel.DataAnnotations;

namespace EventsAPI.Models
{
    /// <summary>
    /// Long term plan to have an array or event types to control other selection items
    /// </summary>
    public class EventType : AuditableEntity
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool Active { get; private set; }

        public EventType(string name, bool active)
        {
            Name = name;
            Active = active;
        }

        public override string ToString()
        {
            return $"EventType Id: {Id} for Name: {Name}";
        }
    }
}