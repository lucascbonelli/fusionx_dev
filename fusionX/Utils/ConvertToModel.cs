using EvenTech.Dtos;
using EvenTech.Models;

namespace EvenTech.Utils
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

        public static void ToModel(Event existingEvent,EventDtoUpdate dto)
        {
            existingEvent.Title = dto.Title;
            existingEvent.Description = dto.Description;
            existingEvent.BeginDate = dto.BeginDate;
            existingEvent.EndDate = dto.EndDate;
            existingEvent.BannerImage = dto.BannerImage;
            existingEvent.UserId = dto.UserId;
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
