namespace hackweek_backend.Models
{
    public class Lecture
    {
        public uint Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        public uint SessionId { get; set; }
        public Session? Session { get; set; }
    }
}
