using EvenTech.Data;
using EvenTech.Dtos;
using EvenTech.Models;
using EvenTech.Services.Interfaces;

namespace EvenTech.Services
{
    public class SessionService : ISessionService
    {
        private readonly DataContext _context;

        public SessionService(DataContext context)
        {
            _context = context;
        }

        public async Task<SessionDto?> GetSessionDayById(uint id)
        {
            var session = await _context.Sessions.FindAsync(id);
            return session != null ? new SessionDto(session) : null;
        }

        public async Task CreateSession(SessionDto request)
        {
            var sessionModel = new Session
            {
                Capacity = request.Capacity,
                EventId = request.EventId,
                LocationId = request.LocationId
            };

            await _context.Sessions.AddAsync(sessionModel);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSession(uint id, SessionDtoUpdate request)
        {
            var session = await _context.Sessions.FindAsync(id);

            if (session == null)
            {
                throw new Exception("Sessão não encontrada!");
            }

            session.Capacity = request.Capacity;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteSession(uint id)
        {
            var session = await _context.Sessions.FindAsync(id);

            if (session == null)
            {
                throw new Exception("Sessão não encontrada!");
            }

            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SessionDto>> GetSessionByEventId(uint eventId)
        {
            var sessions = await _context.Sessions
                .Where(s => s.EventId == eventId)
                .Select(s => new SessionDto(s))
                .ToListAsync();

            return sessions;
        }

        public async Task<int> GetAvailableCapacity(uint sessionId)
        {
            var session = await _context.Sessions.FindAsync(sessionId);

            if (session == null)
            {
                throw new Exception("Sessão não encontrada!");
            }

            var bookedCapacity = await _context.Attendances
                .CountAsync(a => a.SessionId == sessionId && a.Status == "Confirmado");

            var availableCapacity = session.Capacity - bookedCapacity;
            return availableCapacity;
        }

    }
}
