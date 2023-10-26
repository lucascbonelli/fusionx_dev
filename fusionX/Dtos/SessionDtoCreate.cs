using EvenTech.Models;

namespace EvenTech.Dtos
{
    public class SessionDtoCreate
    {
        public int Capacity { get; set; }
        public uint? LocationId { get; set; }
        public ICollection<LectureDtoCreate>? Lectures { get; set; }
    }
}
