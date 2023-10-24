namespace hackweek_backend.Models
{
    public class Event
    {
        public uint Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte[]? BannerImage { get; set; }

        public uint UserId { get; set; }
        public User? User { get; set; }

        public ICollection<EventTag>? Tags { get; set; }
        public ICollection<EventDay>? EventDays { get; set; }
        public ICollection<EventImage>? EventImages { get; set; }

        public Event()
        {
            Tags = new List<EventTag>();
            EventDays = new List<EventDay>();
            EventImages = new List<EventImage>();
        }
    }
}
