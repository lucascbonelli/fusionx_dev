using EvenTech.Data;
using EvenTech.Models;
using EvenTech.Services.Interfaces;

namespace EvenTech.Services
{
    public class EventManagerService : IEventManagerService
    {
        private readonly DataContext _context;

        public EventManagerService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventManager>> GetAllAsync()
        {
            return await _context.EventManagers.ToListAsync();
        }

        public async Task<EventManager> GetByIdAsync(int id)
        {
            return await _context.EventManagers.FindAsync(id);
        }

        public async Task<EventManager> CreateAsync(EventManager eventManager)
        {
            _context.EventManagers.Add(eventManager);
            await _context.SaveChangesAsync();
            return eventManager;
        }

        public async Task UpdateAsync(EventManager eventManager)
        {
            _context.Entry(eventManager).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var eventManager = await _context.EventManagers.FindAsync(id);
            _context.EventManagers.Remove(eventManager);
            await _context.SaveChangesAsync();
        }
    }
}
