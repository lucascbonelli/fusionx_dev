using EvenTech.Dtos;

namespace EvenTech.Services.Interfaces
{
    public interface IUserTagService
    {
        Task<UserTagDto?> GetUserTag(uint tagId, uint userId);
        Task CreateUserTag(UserTagDtoInsert request);
        Task DeleteUserTag(uint tagId, uint userId);

        Task<IEnumerable<UserTagDto>> GetUserTagsByUserId(uint userId);
        Task<IEnumerable<UserTagDto>> GetUserTagsByTagId(uint tagId);
    }
}
