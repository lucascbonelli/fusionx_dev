namespace EvenTech.Dtos
{
    public class EventDtoSessionCreate
    {
        public int Capacity { get; set; }
        public uint? LocationId { get; set; }
        public ICollection<EventDtoLectureCreate>? Lectures { get; set; }
    }
}
