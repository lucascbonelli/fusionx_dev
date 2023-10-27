using EvenTech.Dtos;
using EvenTech.Models;

namespace EvenTech.Utils
{
    public class ConvertToModel
    {
        public static Event ToModel(EventDtoCreate dto)
        {
            var @event = new Event
            {
                Title = dto.Title,
                Description = dto.Description,
                BeginDate = dto.BeginDate,
                EndDate = dto.EndDate,
                BannerImage = dto.BannerImage,
                UserId = dto.UserId,
            };

            if (dto.TagIds != null)
            {
                @event.Tags = dto.TagIds.Select(id => new EventTag
                {
                    TagId = id,
                    EventId = @event.Id,
                }).ToList();
            }

            if (dto.Sessions != null)
            {
                @event.Sessions = dto.Sessions.Select(sessionDto => new Session
                {
                    Capacity = sessionDto.Capacity,
                    LocationId = sessionDto.LocationId,
                    EventId = @event.Id,
                    Lectures = sessionDto.Lectures?.Select(lectureDto => new Lecture
                    {
                        Title = lectureDto.Title,
                        Description = lectureDto.Description,
                        BeginDate = lectureDto.BeginDate,
                        EndDate = lectureDto.EndDate,
                    }).ToList()
                }).ToList();
            }

            if (dto.EventImages != null)
            {
                @event.EventImages = dto.EventImages.Select((image, index) => new EventImage
                {
                    EventId = @event.Id,
                    Position = index,
                    Image = image
                }).ToList();
            }
            return @event;
        }

        public static void ToModel(Event existingEvent, EventDtoUpdate dto)
        {
            existingEvent.Title = dto.Title;
            existingEvent.Description = dto.Description;
            existingEvent.BeginDate = dto.BeginDate;
            existingEvent.EndDate = dto.EndDate;
            existingEvent.BannerImage = dto.BannerImage;
        }

        public static User ToModel(UserDto dto)
        {
            return new User
            {
                Id = dto.Id,
                Email = dto.Email,
                IsEmailConfirmed = dto.IsEmailConfirmed,
                Name = dto.Name,
                VerificationDate = dto.Verified ? DateTime.Now : (DateTime?)null,
                Role = dto.Role
            };
        }
    }
}
