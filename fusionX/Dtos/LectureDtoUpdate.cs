namespace EvenTech.Dtos
{
    public class LectureDtoUpdate
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
