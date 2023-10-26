using hackweek_backend.dtos;
using hackweek_backend.Dtos;
using hackweek_backend.Models;

namespace hackweek_backend.Services.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<EventDto?> GetEventByIdAsync(uint id);
        Task<Event> CreateEventAsync(EventDtoCreate eventDtoCreateItem);
        Task UpdateEventAsync(uint id,EventDtoUpdate eventDtoUpdateItem);
        Task DeleteEventAsync(uint id);
    }
}
