using hackweek_backend.dtos;
using hackweek_backend.Dtos;
using hackweek_backend.Models;

namespace hackweek_backend.Utils
{
    public class ConvertToModel
    {
        public static Event ToModel(EventDtoCreate dto)
        {
            return new Event
            {
                Title = dto.Title,
                Description = dto.Description,
                BeginDate = dto.BeginDate,
                EndDate = dto.EndDate,
                BannerImage = dto.BannerImage,
                UserId = dto.UserId,
                Tags = dto.Tags,
                Sessions = dto.Sessions,
                EventImages = dto.EventImages
            };
        }

        public static User ToModel(UserDto dto)
        {
            return new User
            {
                Id = dto.Id,
                Email = dto.Email,
                IsEmailConfirmed = dto.IsEmailConfirmed,
                Name = dto.Name,
                VerificationDate = dto.Verified ? DateTime.Now : (DateTime?) null,
                Role = dto.Role
            };
        }
    }
}
