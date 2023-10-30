namespace EvenTech.Dtos
{
    public class NotificationDtoUpdate
    {
        public uint Id { get; set; }
        public int Recipient { get; set; }
        public int Type { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime SendDate { get; set; }
    }
}
