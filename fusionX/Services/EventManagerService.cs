using EvenTech.Data;
using EvenTech.dtos;
using EvenTech.Models;
using EvenTech.Models.Constraints;
using EvenTech.Services.Interfaces;
using EvenTech.Utils;

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

        public async Task<EventManager?> GetByIdAsync(uint id)
        {
            return await _context.EventManagers.FindAsync(id);
        }

        public async Task<EventManager> CreateAsync(EventManagerDtoCreate eventManagerDtoCreate)
        {
            var eventManager = new EventManager();
            ConvertToModel.ToModel(eventManager, eventManagerDtoCreate);
            _context.EventManagers.Add(eventManager);
            await _context.SaveChangesAsync();
            return eventManager;
        }

        public async Task DeleteAsync(uint id)
        {
            var eventManager = await _context.EventManagers.FindAsync(id);
            if(eventManager is null) return;
            _context.EventManagers.Remove(eventManager);
            await _context.SaveChangesAsync();
        }

        public async Task UserApprovalAsync(uint id, uint attendanceId)
        {
            var eventManager = await _context.EventManagers.FindAsync(id)
                ?? throw new Exception($"Host do not exist! ({id})");
            var attendance = await _context.Attendances.FindAsync(attendanceId)
                ?? throw new Exception($"Attendance do not exist! ({id})");
            attendance.EventManagerId = eventManager.Id;
            attendance.Status = FeedbackConstraints.Status.Present;
            await _context.SaveChangesAsync();
        }
    }
}
