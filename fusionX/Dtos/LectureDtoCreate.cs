using EvenTech.Models;

namespace EvenTech.Dtos
{
    public class LectureDtoCreate
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
