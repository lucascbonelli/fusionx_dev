namespace EvenTech.Models
{
    public class Notification
    {
        public uint Id { get; set; }
        public int Recipient { get; set; }
        public int Type { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime SendDate { get; set; }

        public uint EventId { get; set; }
        public Event? Event { get; set; }
    }
}
