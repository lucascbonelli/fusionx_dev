using EvenTech.Data;
using EvenTech.Dtos;
using EvenTech.Models;
using EvenTech.Services.Interfaces;
using System.Data;

namespace EvenTech.Services
{
    public class UserTagService : IUserTagService
    {
        private readonly DataContext _context;

        public UserTagService(DataContext context)
        {
            _context = context;
        }

        public async Task<UserTagDto?> GetUserTag(uint tagId, uint userId)
        {
            var userTag = await _context.UserTags.FirstOrDefaultAsync(ut => ut.TagId == tagId && ut.UserId == userId);

            return userTag != null ? new UserTagDto(userTag) : null;
        }

        public async Task CreateUserTag(UserTagDtoInsert request)
        {
            var userTagModel = new UserTag
            {
                TagId = request.TagId,
                UserId = request.UserId,
                Occurrences = request.Occurrences
            };

            await _context.UserTags.AddAsync(userTagModel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserTag(uint tagId, uint userId)
        {
            var userTag = await _context.UserTags.FindAsync(tagId);

            if (userTag != null && userTag.UserId == userId)
            {
                _context.UserTags.Remove(userTag);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("UserTag não encontrada ou a combinação de tagId e userId não corresponde.");
            }
        }


        public async Task<IEnumerable<UserTagDto>> GetUserTagsByUserId(uint userId)
        {
            var userTags = await _context.UserTags
                .Where(ut => ut.TagId == userId)
                .Select(ut => new UserTagDto(ut))
                .ToListAsync();

            return userTags;
        }

        public async Task<IEnumerable<UserTagDto>> GetUserTagsByTagId(uint tagId)
        {
            var userTags = await _context.UserTags
                .Where(ut => ut.UserId == tagId)
                .Select(ut => new UserTagDto(ut))
                .ToListAsync();

            return userTags;
        }

    }
}
