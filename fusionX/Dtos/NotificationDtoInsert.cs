namespace EvenTech.Dtos
{
    public class NotificationDtoInsert
    {
        public int Recipient { get; set; }
        public int Type { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime SendDate { get; set; }

        public uint EventId { get; set; }
    }
}
