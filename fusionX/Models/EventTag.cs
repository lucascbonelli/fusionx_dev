namespace EvenTech.Models
{
    public class EventTag
    {
        public uint TagId { get; set; }
        public Tag? Tag { get; set; }

        public uint EventId { get; set; }
        public Event? Event { get; set; }
    }
}
