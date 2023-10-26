using EvenTech.Dtos;

namespace EvenTech.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> GetUserById(uint id);
        Task CreateUser(UserDtoInsert request);
        Task DeleteUser(uint id);
        Task UpdateUser(uint id, UserDtoUpdate request);

        Task<UserDto?> GetUserByEmail(string email);
    }
}