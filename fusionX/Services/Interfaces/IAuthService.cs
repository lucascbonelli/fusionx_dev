using EvenTech.Dtos;

namespace EvenTech.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(AuthDtoLogin request);

        bool HasAccessToUser(HttpContext httpContext, uint idUser);
        string GetUserRole(HttpContext httpContext);
    }
}