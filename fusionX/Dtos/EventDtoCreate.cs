namespace EvenTech.Dtos
{
    public class EventDtoCreate
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte[]? BannerImage { get; set; }

        public uint UserId { get; set; }

        public ICollection<uint>? TagIds { get; set; }
        public ICollection<EventDtoSessionCreate>? Sessions { get; set; }
        public ICollection<byte[]>? EventImages { get; set; }
    }
}
