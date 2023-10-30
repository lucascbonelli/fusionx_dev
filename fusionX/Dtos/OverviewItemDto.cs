namespace EvenTech.Dtos
{
    public class OverviewItemDto
    {
        public uint Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Count { get; set; }
        public NotificationTypeDto? Type { get; set; }

        public string Response { get; set; } = string.Empty;
    }
}
