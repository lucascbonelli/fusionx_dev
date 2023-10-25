using hackweek_backend.Data;
using hackweek_backend.Dtos;
using hackweek_backend.Models;
using hackweek_backend.Services.Interfaces;
using hackweek_backend.Utils;

namespace hackweek_backend.Services
{
    public class EventService : IEventService
    {
        private readonly DataContext _context;

        public EventService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<EventDto?> GetEventByIdAsync(uint id)
        {
            var modelEvent = await _context.Events.FindAsync(id);
            if (modelEvent is null)
            {
                return null;
            }
            return new EventDto(modelEvent);
        }

        public async Task<Event> CreateEventAsync(EventDtoCreate eventDtoCreateItem)
        {
            var eventModel = ConvertToModel.ToModel(eventDtoCreateItem);
            _context.Events.Add(eventModel);
            await _context.SaveChangesAsync();
            return eventModel;
        }

        public async Task UpdateEventAsync(uint id,EventDtoUpdate eventDtoUpdateItem)
        {
            var existingEvent = await _context.Events.FindAsync(id);
            if (existingEvent == null)
            {
                throw new InvalidOperationException($"Event with ID {id} not found.");
            }
            ConvertToModel.ToModel(existingEvent,eventDtoUpdateItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(uint id)
        {
            var eventToDelete = await _context.Events.FindAsync(id);
            if (eventToDelete != null)
            {
                _context.Events.Remove(eventToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
