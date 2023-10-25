using hackweek_backend.Models;

namespace hackweek_backend.Dtos
{
    public class EventDtoCreate
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte[]? BannerImage { get; set; }

        public uint UserId { get; set; }

        public ICollection<EventTag>? Tags { get; set; } = new List<EventTag>();
        public ICollection<Session>? Sessions { get; set; } = new List<Session>();
        public ICollection<EventImage>? EventImages { get; set; } = new List<EventImage>();
    }
}
