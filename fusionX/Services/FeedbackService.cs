using EvenTech.Data;
using EvenTech.Dtos;
using EvenTech.Models;
using EvenTech.Services.Interfaces;

namespace EvenTech.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly DataContext _context;

        public FeedbackService(DataContext context)
        {
            _context = context;
        }

        public async Task<FeedbackDto?> GetFeedbackById(uint id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            return feedback != null ? new FeedbackDto(feedback) : null;
        }

        public async Task CreateFeedback(FeedbackDto request)
        {
            var feedbackModel = new Feedback
            {
                Response = request.Response,
                Date = DateTime.Now,
                NotificationId = request.NotificationId,
                UserId = request.UserId
            };

            await _context.Feedbacks.AddAsync(feedbackModel);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFeedback(uint id, FeedbackDtoUpdate request)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);

            if (feedback == null)
            {
                throw new Exception("Feedback não encontrado!");
            }

            feedback.Response = request.Response;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteFeedback(uint id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);

            if (feedback == null)
            {
                throw new Exception("Feedback não encontrado!");
            }

            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FeedbackDto>> GetFeedbackByUserId(uint userId)
        {
            var feedbacks = await _context.Feedbacks
                .Where(f => f.UserId == userId)
                .Select(f => new FeedbackDto(f))
                .ToListAsync();

            return feedbacks;
        }

        public async Task<IEnumerable<FeedbackDto>> GetFeedbackByNotificationId(uint notificationId)
        {
            var feedbacks = await _context.Feedbacks
                .Where(f => f.NotificationId == notificationId)
                .Select(f => new FeedbackDto(f))
                .ToListAsync();

            return feedbacks;
        }
    }
}
