using EvenTech.Models;

namespace EvenTech.Dtos
{
    public class UserTagDto
    {
        public uint TagId { get; set; }
        public uint UserId { get; set; }
        public int Occurrences { get; set; }

        public UserTagDto(UserTag userTag)
        {
            TagId = userTag.TagId;
            UserId = userTag.UserId;
            Occurrences = userTag.Occurrences;
        }
    }
}
