namespace EvenTech.Models
{
    public class EventImage
    {
        public uint Id { get; set; }

        public uint EventId { get; set; }
        public Event? Event { get; set; }

        public int Position { get; set; }
        public byte[]? Image { get; set; }
    }
}
