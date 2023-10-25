namespace hackweek_backend.Dtos
{
    public class EventDtoUpdate
    {
        public uint Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte[]? BannerImage { get; set; }

        public uint UserId { get; set; }
    }
}
