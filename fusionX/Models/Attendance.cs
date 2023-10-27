using System.ComponentModel.DataAnnotations.Schema;

namespace EvenTech.Models
{
    public class Attendance
    {
        public uint Id { get; set; }
        public string Status { get; set; } = string.Empty;

        public uint SessionId { get; set; }
        public Session? Session { get; set; }

        public uint UserId { get; set; }
        public User? User { get; set; }

        public uint? EventManagerId { get; set; }
        public EventManager? EventManager { get; set; }
    }
}
