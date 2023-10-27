using EvenTech.Models;

namespace EvenTech.Services.Interfaces
{
    public interface IEventManagerService
    {
        Task<IEnumerable<EventManager>> GetAllAsync();
        Task<EventManager> GetByIdAsync(int id);
        Task<EventManager> CreateAsync(EventManager eventManager);
        Task UpdateAsync(EventManager eventManager);
        Task DeleteAsync(int id);
    }
}
