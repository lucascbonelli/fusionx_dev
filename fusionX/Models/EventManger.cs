using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EvenTech.Models
{
    public class EventManager
    {
        [Key]
        public uint Id { get; set; }

        [ForeignKey(nameof(Event))]
        public uint EventId { get; set; }
        public virtual required Event Event { get; set; }

        [ForeignKey(nameof(User))]
        public uint UserId { get; set; }
        public virtual required User User { get; set; }
    }
}
