using EvenTech.Dtos;

namespace EvenTech.Services.Interfaces
{
    public interface IFeedbackService
    {
        Task<FeedbackDto?> GetFeedbackById(uint id);
        Task CreateFeedback(FeedbackDto request);
        Task UpdateFeedback(uint id, FeedbackDtoUpdate request);
        Task DeleteFeedback(uint id);

        Task<IEnumerable<FeedbackDto>> GetFeedbackByUserId(uint userId);
        Task<IEnumerable<FeedbackDto>> GetFeedbackByNotificationId(uint notificationId);
    }
}
