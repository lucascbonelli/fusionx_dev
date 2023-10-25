using EvenTech.Dtos;

namespace EvenTech.Services.Interfaces
{
    public interface IUserTokenService
    {
        Task<UserTokenDto> GenerateUserToken(string email);
        Task DeleteUserToken(uint idUser);
    }
}