using EvenTech.Data;
using EvenTech.Dtos;
using EvenTech.Models;
using EvenTech.Services.Interfaces;

namespace EvenTech.Services
{
    public class TagService : ITagService
    {
        private readonly DataContext _context;

        public TagService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tag>> GetAllTagsAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<Tag?> GetTagByIdAsync(uint id)
        {
            return await _context.Tags.FindAsync(id);
        }

        public async Task<Tag> CreateTagAsync(TagDtoCreate tagDto)
        {
            var tag = new Tag
            {
                Description = tagDto.Description,
            };
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task UpdateTagAsync(Tag tag)
        {
            _context.Tags.Update(tag);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTagAsync(uint id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync();
            }
        }
    }
}
