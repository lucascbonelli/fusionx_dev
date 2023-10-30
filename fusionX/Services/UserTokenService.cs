using EvenTech.Data;
using EvenTech.Dtos;
using EvenTech.Models;
using EvenTech.Services.Interfaces;

namespace EvenTech.Services
{
    public class UserTokenService : IUserTokenService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;
        private readonly IUserService _userService;

        public UserTokenService(DataContext context, IConfiguration config, IUserService userService)
        {
            _context = context;
            _config = config;
            _userService = userService;
        }

        public async Task<UserTokenDto> GenerateUserToken(string email)
        {
            var userToken = await _context.UserTokens.FirstOrDefaultAsync(u => u.Email == email);
            var user = await _userService.GetUserByEmail(email) ?? throw new Exception($"Email não encontrado! ({email})");
            var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

            if (userToken == null)
            {
                userToken = new UserToken
                {
                    UserId = user.Id,
                    Email = email,
                    Token = token,
                    ExpirationDate = DateTime.Now.AddMinutes(int.Parse(_config["Email:MinsExpire"] ?? "30")),
                };
                await _context.UserTokens.AddAsync(userToken);
            }
            else
            {
                userToken.Token = token;
            }

            await _context.SaveChangesAsync();

            var dto = new UserTokenDto(userToken);
            dto.User = user;

            return dto;
        }

        public async Task DeleteUserToken(uint idUser)
        {
            var userToken = await _context.UserTokens.FindAsync(idUser) ?? throw new Exception("Token não encontrado!");

            _context.UserTokens.Remove(userToken);
            await _context.SaveChangesAsync();
        }
    }
}