namespace EvenTech.Models
{
    public class NotificationTemplate
    {
        public uint Id { get; set; }
        public int Recipient { get; set; }
        public int Type { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
