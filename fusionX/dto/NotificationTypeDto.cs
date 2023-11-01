using EvenTech.Models;

namespace EvenTech.Dtos
{
    public class NotificationTypeDto
    {
        public uint Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public NotificationTypeDto(NotificationType model)
        {
            Id = model.Id;
            Description = model.Description;
        }
    }
}
