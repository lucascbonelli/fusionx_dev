using EvenTech.Data;
using EvenTech.Dtos;
using EvenTech.Models;
using EvenTech.Services.Interfaces;

namespace EvenTech.Controllers
{
    public class LecturesService : ILectureService
    {
        private readonly DataContext _context;

        public LecturesService(DataContext context)
        {
            _context = context;
        }

        public async Task<LectureDto?> GetLectureById(uint id)
        {
            var lecture = await _context.Lectures.FindAsync(id);
            return lecture != null ? new LectureDto(lecture) : null;
        }

        public async Task CreateLecture(LectureDto request)
        {
            var lectureModel = new Lecture
            {
                Title = request.Title,
                Description = request.Description,
                BeginDate = request.BeginDate,
                EndDate = request.EndDate,
                SessionId = request.SessionId
            };

            await _context.Lectures.AddAsync(lectureModel);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLecture(uint id, LectureDtoUpdate request)
        {
            var lecture = await _context.Lectures.FindAsync(id);

            if (lecture == null)
            {
                throw new Exception("Palestra não encontrada!");
            }

            lecture.Title = request.Title;
            lecture.Description = request.Description;
            lecture.BeginDate = request.BeginDate;
            lecture.EndDate = request.EndDate;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteLecture(uint id)
        {
            var lecture = await _context.Lectures.FindAsync(id);

            if (lecture == null)
            {
                throw new Exception("Palestra não encontrada!");
            }

            _context.Lectures.Remove(lecture);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LectureDto>> GetLecturesBySessionId(uint sessionId)
        {
            var lectures = await _context.Lectures
                .Where(lecture => lecture.SessionId == sessionId)
                .Select(lecture => new LectureDto
                {
                    Id = lecture.Id,
                    Title = lecture.Title,
                    Description = lecture.Description,
                    BeginDate = lecture.BeginDate,
                    EndDate = lecture.EndDate,
                    SessionId = lecture.SessionId
                })
                .ToListAsync();

            return lectures;
        }

        public async Task<IEnumerable<LectureDto>> GetLecturesByEventId(uint eventId)
        {
            var lectures = await _context.Lectures
                .Include(lecture => lecture.Session)
                .Where(lecture => (lecture.Session != null) && (lecture.Session.EventId == eventId))
                .Select(lecture => new LectureDto
                {
                    Id = lecture.Id,
                    Title = lecture.Title,
                    Description = lecture.Description,
                    BeginDate = lecture.BeginDate,
                    EndDate = lecture.EndDate,
                    SessionId = lecture.SessionId
                })
                .ToListAsync();

            return lectures;
        }
    }
}
