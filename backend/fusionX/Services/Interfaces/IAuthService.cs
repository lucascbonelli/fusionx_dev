using hackweek_backend.dtos;

namespace hackweek_backend.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(AuthDtoLogin request);
        Task ConfirmEmail(string token);
        Task<string> Recovery(string email);

        bool HasAccessToUser(HttpContext httpContext, uint idUser);
        string GetUserRole(HttpContext httpContext);
    }
}