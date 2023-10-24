namespace hackweek_backend.Dtos
{
    public class UserDtoUpdate
    {
        public uint Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}