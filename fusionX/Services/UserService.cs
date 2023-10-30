using EvenTech.Data;
using EvenTech.Dtos;
using EvenTech.Models;
using EvenTech.Models.Constraints;
using EvenTech.Services.Interfaces;

namespace EvenTech.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        private readonly string[] _allowCreateRoleList = {
            UserConstraints.Roles.Company,
            UserConstraints.Roles.User,
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

        public async Task UpdateUser(uint id, UserDtoUpdate request)
        {
            if (request.Id != id) throw new Exception($"Id diferente do usuário informado! ({id} - {request.Id})");

            var user = await _context.Users.FindAsync(id) ?? throw new Exception($"Usuário não encontrado! ({request.Id})");

            user.Name = request.Name;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateLastAccess(uint id, DateTime lastAccess)
        {
            var user = await _context.Users.FindAsync(id) ?? throw new Exception($"Usuário não encontrado! ({id})");

            user.LastAccess = lastAccess;

            await _context.SaveChangesAsync();
        }
    }
}