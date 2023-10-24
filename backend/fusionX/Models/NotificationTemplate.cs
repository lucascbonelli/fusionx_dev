namespace hackweek_backend.Models
{
    public class NotificationTemplate
    {
        public uint Id { get; set; }
        public int Type { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
