using hackweek_backend.Dtos;

namespace hackweek_backend.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(AuthDtoLogin request);

        bool HasAccessToUser(HttpContext httpContext, uint idUser);
        string GetUserRole(HttpContext httpContext);
    }
}