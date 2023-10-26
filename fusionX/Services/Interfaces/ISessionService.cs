using EvenTech.Dtos;
using EvenTech.Models;

namespace EvenTech.Services.Interfaces
{
    public interface ISessionService
    {
        Task<SessionDto?> GetSessionDayById(uint id);
        Task<Session> CreateSession(SessionDtoInsert request);
        Task UpdateSession(uint id, SessionDtoUpdate request);
        Task DeleteSession(uint id);

        Task<IEnumerable<SessionDto>> GetSessionByEventId(uint eventId);
        Task<int> GetAvailableCapacity(uint sessionId);
    }
}
