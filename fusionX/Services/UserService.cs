using hackweek_backend.Data;
using hackweek_backend.Dtos;
using hackweek_backend.Models;
using hackweek_backend.Services.Interfaces;
using System.Data;
using System.Security.Cryptography;

namespace hackweek_backend.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        private readonly string[] _allowCreateRoleList = {
            UserRoles.Company,
            UserRoles.User,
        };

        private readonly string[] _allowGetByRoleList = {
            UserRoles.Company,
            UserRoles.User,
        };

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<UserDto?> GetUserById(uint id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null) return null;

            return new UserDto(user);
        }

        public async Task CreateUser(UserDtoInsert request)
        {
            if (_context.Users.FirstOrDefault(u => u.Email == request.Email) != null) throw new Exception($"Usuário já cadastrado! ({request.Email})");

            if (_allowCreateRoleList.FirstOrDefault(r => r == request.Role) == null) throw new Exception($"Cargo inválido! ({request.Role})");

            var userModel = new User
            {
                Email = request.Email,
                Name = request.Name,
                Role = request.Role,
            };

            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(uint id)
        {
            var user = await _context.Users.FindAsync(id) ?? throw new Exception("Usuário não encontrado!");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<UserDto?> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null) return null;

            return new UserDto(user);
        }

        public async Task<string> RedefinePassword(uint id)
        {
            var user = await _context.Users.FindAsync(id) ?? throw new Exception($"Usuário não cadastrado! ({id}");

            var passwordLength = 12;
            var specialCharacters = "!@#$%^&*";

            using (var rng = RandomNumberGenerator.Create())
            {
                var bytes = new byte[passwordLength];
                rng.GetBytes(bytes);

                var password = Convert.ToBase64String(bytes)
                    .Replace("/", string.Empty)
                    .Replace("+", string.Empty)
                    .Substring(0, passwordLength);

                var random = new Random();
                for (int i = 0; i < 2; i++)
                {
                    int specialCharIndex = random.Next(0, specialCharacters.Length);
                    int position = random.Next(0, password.Length);
                    password = password.Remove(position, 1).Insert(position, specialCharacters[specialCharIndex].ToString());
                }

                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
                await _context.SaveChangesAsync();

                return password;
            }
        }

        public async Task UpdateUser(uint id, UserDtoUpdate request)
        {
            if (request.Id != id) throw new Exception($"Id diferente do usuário informado! ({id} - {request.Id})");

            var user = await _context.Users.FindAsync(id) ?? throw new Exception($"Usuário não encontrado! ({request.Id})");

            user.Email = request.Email;
            user.Name = request.Name;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDto>> GetUsersEventByRole(string role)
        {
            if (_allowGetByRoleList.FirstOrDefault(r => r == role) == null) return new List<UserDto>();

            return await _context.Users.Where(u => u.Role == role)
                .Select(u => new UserDto(u))
                .ToListAsync();
        }
    }
}