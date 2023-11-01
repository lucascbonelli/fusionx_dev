using EvenTech.Models;

namespace EvenTech.Dtos
{
    public class NotificationDto
    {
        public uint Id { get; set; }
        public int Recipient { get; set; }
        public int Type { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime SendDate { get; set; }

        public uint EventId { get; set; }
        public EventDto? Event { get; set; }

        public NotificationDto() { }

        public NotificationDto(Notification model)
        {
            Id = model.Id;
            Recipient = model.Recipient;
            Type = model.Type;
            Title = model.Title;
            Description = model.Description;
            SendDate = model.SendDate;
            EventId = model.EventId;
            Event = (model.Event is null) ? null : new EventDto(model.Event);
        }
    }
}
