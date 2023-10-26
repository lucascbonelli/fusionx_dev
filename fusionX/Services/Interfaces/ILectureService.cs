using hackweek_backend.Dtos;

namespace hackweek_backend.Services.Interfaces
{
    public interface ILectureService
    {
        Task<LectureDto?> GetLectureById(uint id);
        Task CreateLecture(LectureDto request);
        Task UpdateLecture(uint id, LectureDtoUpdate request);
        Task DeleteLecture(uint id);


        Task<IEnumerable<LectureDto>> GetLecturesBySessionId(uint sessionId);
        Task<IEnumerable<LectureDto>> GetLecturesByEventId(uint eventId);
    }
}