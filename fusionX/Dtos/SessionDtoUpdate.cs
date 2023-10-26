namespace EvenTech.Dtos
{
    public class SessionDtoUpdate
    {
        public DateTime Date { get; set; }
        public int Capacity { get; set; }
        public uint EventId { get; set; }
        public uint? LocationId { get; set; }
    }
}
