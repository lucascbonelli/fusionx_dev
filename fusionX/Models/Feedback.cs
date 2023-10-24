namespace hackweek_backend.Models
{
    public class Feedback
    {
        public uint Id { get; set; }
        public string Response { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        public uint NotificationId { get; set; }
        public Notification? Notification { get; set; }

        public uint UserId { get; set; }
        public User? User { get; set; }
    }
}
