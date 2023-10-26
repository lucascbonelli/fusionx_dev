using EvenTech.Models;

namespace EvenTech.Dtos
{
    public class SessionDto
    {
        public uint Id { get; set; }
        public int Capacity { get; set; }
        public uint EventId { get; set; }
        public uint? LocationId { get; set; }
        public SessionDto(Session session)
        {
            Id = session.Id;
            Capacity = session.Capacity;
            EventId = session.EventId;
            LocationId = session.LocationId;

        }
    }
}
