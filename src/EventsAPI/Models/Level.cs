using System.ComponentModel.DataAnnotations;

namespace EventsAPI.Models
{
    /// <summary>
    /// Detail the quality of both event and attendee!
    /// UNSURE IF WILL REMAIN
    /// </summary>
    public class Level : AuditableEntity
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool Active { get; private set; }

        public Level()
        {
        }

        public override string ToString()
        {
            return $"Level Id: {Id} for Name: {Name}";
        }
    }
}