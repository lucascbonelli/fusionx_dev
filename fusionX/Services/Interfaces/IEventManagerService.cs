using EvenTech.dtos;
using EvenTech.Models;

namespace EvenTech.Services.Interfaces
{
    public interface IEventManagerService
    {
        Task<IEnumerable<EventManager>> GetAllAsync();
        Task<EventManager> GetByIdAsync(int id);
        Task<EventManager> CreateAsync(EventManagerDtoCreate eventManagerDtoCreate);
        Task UpdateAsync(EventManager eventManager);
        Task DeleteAsync(int id);
    }
}
