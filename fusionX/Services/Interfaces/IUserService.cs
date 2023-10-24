using hackweek_backend.Dtos;

namespace hackweek_backend.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> GetUserById(uint id);
        Task CreateUser(UserDtoInsert request);
        Task DeleteUser(uint id);
        Task UpdateUser(uint id, UserDtoUpdate request);

        Task<UserDto?> GetUserByEmail(string email);

        Task<string> RedefinePassword(uint id);
        Task<IEnumerable<UserDto>> GetUsersEventByRole(string role);
    }
}