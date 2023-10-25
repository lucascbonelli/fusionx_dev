using EvenTech.Data;
using EvenTech.Dtos;
using EvenTech.Models;
using EvenTech.Services.Interfaces;

namespace EvenTech.Services
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

        public async Task<Event> CreateEventAsync(Event eventItem)
        {
            _context.Events.Add(eventItem);
            await _context.SaveChangesAsync();
            return eventItem;
        }

        public async Task UpdateEventAsync(Event eventItem)
        {
            _context.Entry(eventItem).State = EntityState.Modified;
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

        public async Task<uint?> GetUserIdByEvent(uint id)
        {
            var model = await _context.Events.FindAsync(id);

            return model?.UserId;
        }
    }
}
