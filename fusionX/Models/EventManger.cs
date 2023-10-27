using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EvenTech.Models
{
    public class EventManager
    {
        public uint Id { get; set; }

        public uint EventId { get; set; }
        public Event? Event { get; set; }

        public uint UserId { get; set; }
        public User? User { get; set; }
    }
}
