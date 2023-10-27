using EvenTech.Data;
using EvenTech.Dtos;
using EvenTech.Models;
using EvenTech.Services.Interfaces;

namespace EvenTech.Services
{
    public class EventTagService : IEventTagService
    {
        private readonly DataContext _context;

        public EventTagService(DataContext context)
        {
            _context = context;
        }

        public async Task<EventTagDto?> GetEventTagById(uint tagId, uint eventId)
        {
            var eventTag = await _context.EventTags
                .FirstOrDefaultAsync(et => et.TagId == tagId && et.EventId == eventId);

            return eventTag != null ? new EventTagDto { TagId = eventTag.TagId, EventId = eventTag.EventId } : null;
        }

        public async Task CreateEventTag(EventTagDto request)
        {
            var eventTagModel = new EventTag
            {
                TagId = request.TagId,
                EventId = request.EventId
            };

            await _context.EventTags.AddAsync(eventTagModel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEventTag(uint tagId, uint eventId)
        {
            var eventTag = await _context.EventTags
                .FirstOrDefaultAsync(et => et.TagId == tagId && et.EventId == eventId);

            if (eventTag == null)
            {
                throw new Exception("Tag do evento não encontrada!");
            }

            _context.EventTags.Remove(eventTag);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EventTagDto>> GetEventTagsByEventId(uint eventId)
        {
            var eventTags = await _context.EventTags
                .Where(et => et.EventId == eventId)
                .Select(et => new EventTagDto { TagId = et.TagId, EventId = et.EventId })
                .ToListAsync();

            return eventTags;
        }

        public async Task<IEnumerable<EventTagDto>> GetEventsByTagId(uint tagId)
        {
            var eventTags = await _context.EventTags
                .Where(et => et.TagId == tagId)
                .Select(et => new EventTagDto { TagId = et.TagId, EventId = et.EventId })
                .ToListAsync();

            return eventTags;
        }
    }
}
