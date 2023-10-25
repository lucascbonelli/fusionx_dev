using EvenTech.Dtos;
using EvenTech.Models;

namespace EvenTech.Services.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> GetAllTagsAsync();
        Task<Tag?> GetTagByIdAsync(uint id);
        Task<Tag> CreateTagAsync(TagDtoCreate tagDto);
        Task UpdateTagAsync(Tag tag);
        Task DeleteTagAsync(uint id);
    }
}
