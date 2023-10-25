namespace EvenTech.Models
{
    public class Session
    {
        public uint Id { get; set; }
        public DateTime Date { get; set; }
        public int Capacity { get; set; }

        public uint EventId { get; set; }
        public Event? Event { get; set; }

        public uint? LocationId { get; set; }
        public Location? Location { get; set; }

        public ICollection<Lecture>? Lectures { get; set; }
    }
}
