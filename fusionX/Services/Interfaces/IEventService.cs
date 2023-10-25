using EvenTech.Dtos;
using EvenTech.Models;

namespace EvenTech.Services.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<EventDto?> GetEventByIdAsync(uint id);
        Task<Event> CreateEventAsync(Event eventItem);
        Task UpdateEventAsync(Event eventItem);
        Task DeleteEventAsync(uint id);

        Task<uint?> GetUserIdByEvent(uint id);
    }
}
