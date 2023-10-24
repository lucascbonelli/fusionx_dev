using hackweek_backend.dtos;

namespace hackweek_backend.Services.Interfaces
{
    public interface IUserTokenService
    {
        Task<UserTokenDto> GenerateUserToken(string email);
        Task DeleteUserToken(uint idUser);
    }
}