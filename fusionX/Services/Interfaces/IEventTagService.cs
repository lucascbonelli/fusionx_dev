using EvenTech.Dtos;

namespace EvenTech.Services.Interfaces
{
    public interface IEventTagService
    {
        Task<EventTagDto?> GetEventTagById(uint tagId, uint eventId);
        Task CreateEventTag(EventTagDto request);
        Task DeleteEventTag(uint tagId, uint eventId);

        Task<IEnumerable<EventTagDto>> GetEventTagsByEventId(uint eventId);
        Task<IEnumerable<EventTagDto>> GetEventsByTagId(uint tagId);
    }
}
