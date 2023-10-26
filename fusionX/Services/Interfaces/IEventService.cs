using EvenTech.Dtos;
using EvenTech.Models;

namespace EvenTech.Services.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<EventDto?> GetEventByIdAsync(uint id);
        Task<Event> CreateEventAsync(EventDtoCreate eventDtoCreateItem);
        Task UpdateEventAsync(uint id, EventDtoUpdate eventDtoUpdateItem);
        Task DeleteEventAsync(uint id);

        Task<uint?> GetUserIdByEvent(uint id);
    }
}
