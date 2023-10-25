using hackweek_backend.Data;
using hackweek_backend.Dtos;
using hackweek_backend.Models;
using hackweek_backend.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace hackweek_backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;

        public AuthService(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _config = configuration;
        }

        public async Task<string> Login(AuthDtoLogin request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email) ?? throw new Exception("Usuário não encontrado!");

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash)) throw new Exception("Senha incorreta!");

            return GenerateToken(user);
        }

        private string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.Name),
                new Claim(ClaimTypes.IsPersistent, (user.VerificationDate != null).ToString()),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static UserDto? GetCurrentUser(HttpContext httpContext)
        {
            var claimsIdentity = httpContext.User.Identity as ClaimsIdentity;
            if (claimsIdentity is null) return null;

            var nameId = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var email = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            var givenName = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName);
            var persistent = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.IsPersistent);
            var role = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

            if ((nameId is null) || (email is null) || (givenName is null) || (persistent is null) || (role is null))
                return null;

            return new UserDto
            {
                Id = uint.Parse(nameId.Value),
                Email = email.Value,
                Name = givenName.Value,
                Verified = bool.Parse(persistent.Value),
                Role = role.Value
            };
        }

        public bool HasAccessToUser(HttpContext httpContext, uint idUser)
        {
            var user = GetCurrentUser(httpContext);
            if (user == null) return false;

            return (user.Role == UserRoles.Admin) || (user.Id == idUser);
        }

        public string GetUserRole(HttpContext httpContext)
        {
            var user = GetCurrentUser(httpContext);
            if (user == null) return "";

            return user.Role;
        }
    }
}
