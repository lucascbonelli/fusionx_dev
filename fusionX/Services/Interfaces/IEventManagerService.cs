using EvenTech.dtos;
using EvenTech.Models;

namespace EvenTech.Services.Interfaces
{
    public interface IEventManagerService
    {
        Task<IEnumerable<EventManager>> GetAllAsync();
        Task<EventManager?> GetByIdAsync(uint id);
        Task<EventManager> CreateAsync(EventManagerDtoCreate eventManagerDtoCreate);
        Task DeleteAsync(uint id);
    }
}
