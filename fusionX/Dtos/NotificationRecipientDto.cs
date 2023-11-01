using EvenTech.Models;

namespace EvenTech.Dtos
{
    public class NotificationRecipientDto
    {
        public uint Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public NotificationRecipientDto(NotificationRecipient model)
        {
            Id = model.Id;
            Description = model.Description;
        }
    }
}
