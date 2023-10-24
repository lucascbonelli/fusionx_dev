using hackweek_backend.Models;

namespace hackweek_backend.dtos
{
    public class EventDto
    {
        public uint Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte[]? BannerImage { get; set; }

        public uint UserId { get; set; }
        public UserDto? UserDto { get; set; }

        public ICollection<EventTag>? Tags { get; set; } = new List<EventTag>();
        public ICollection<Session>? Sessions { get; set; } = new List<Session>();
        public ICollection<EventImage>? EventImages { get; set; } = new List<EventImage>();

        public EventDto(Event @event)
        {
            if (@event != null)
            {
                Id = @event.Id;
                Title = @event.Title;
                Description = @event.Description;
                BeginDate = @event.BeginDate;
                EndDate = @event.EndDate;
                BannerImage = @event.BannerImage;
                UserId = @event.UserId;
                UserDto = new UserDto(@event.User);
                Tags = @event.Tags;
                Sessions = @event.Sessions;
                EventImages = @event.EventImages;
            }
        }
    }
}
