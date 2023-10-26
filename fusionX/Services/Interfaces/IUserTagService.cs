using EvenTech.Dtos;

namespace EvenTech.Services.Interfaces
{
    public interface IUserTagService
    {
        // Métodos CRUD
        Task<UserTagDto?> GetUserTag(uint tagId, uint userId);
        Task CreateUserTag(UserTagDtoInsert request);
        Task DeleteUserTag(uint tagId, uint userId);

        // Métodos Adicionais
        Task<IEnumerable<UserTagDto>> GetUserTagsByUserId(uint userId);
        Task<IEnumerable<UserTagDto>> GetUserTagsByTagId(uint tagId);
    }
}
