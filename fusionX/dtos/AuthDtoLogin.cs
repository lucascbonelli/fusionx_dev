namespace EvenTech.Dtos
{
    public class AuthDtoLogin
    {
        public required string Email { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
    }
}