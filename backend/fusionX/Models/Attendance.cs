namespace hackweek_backend.Models
{
    public class Attendance
    {
        public uint Id { get; set; }
        public string Status { get; set; } = string.Empty;

        public uint LectureId { get; set; }
        public Session? EventDay { get; set; }

        public uint UserId { get; set; }
        public User? User { get; set; }
    }
}
