using EvenTech.Data;
using EvenTech.Dtos;
using EvenTech.Models;
using EvenTech.Models.Constraints;
using EvenTech.Services.Interfaces;
using System.Data;

namespace EvenTech.Services
{
    public class NotificationService : INotificationService
    {
        private readonly DataContext _context;
        private readonly IFeedbackService _feedback;

        public NotificationService(DataContext context, IFeedbackService feedback)
        {
            _context = context;
            _feedback = feedback;
        }

        public async Task<NotificationDto?> GetNotificationByIdAsync(uint id)
        {
            var model = await _context.Notifications.FindAsync(id);
            if (model == null) return null;

            return new NotificationDto(model);
        }

        public async Task CreateNotificationAsync(NotificationDtoInsert request)
        {
            var model = new Notification
            {
                Recipient = request.Recipient,
                Type = request.Type,
                Description = request.Description,
                SendDate = request.SendDate,
                EventId = request.EventId,
            };
            _context.Notifications.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNotificationAsync(uint id, NotificationDtoUpdate request)
        {
            if (request.Id != id) throw new Exception($"Id diferente da notificação informada! ({id} - {request.Id})");

            var model = await _context.Notifications.FindAsync(id) ?? throw new Exception($"Notificação não encontrada! ({request.Id})");

            model.Recipient = request.Recipient;
            model.Type = request.Type;
            model.Description = request.Description;
            model.SendDate = request.SendDate;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteNotificationAsync(uint id)
        {
            var model = await _context.Notifications.FindAsync(id) ?? throw new Exception($"Notificação não encontrada! ({id})");

            _context.Notifications.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<uint?> GetUserIdByNotification(uint id)
        {
            var model = await _context.Notifications
                .Include(n => n.Event)
                .FirstOrDefaultAsync(n => n.Id == id);

            return model?.Event?.UserId;
        }

        public async Task<IEnumerable<NotificationDto>> GetNotificationsByEvent(uint idEvent)
        {
            return await _context.Notifications
                .Where(n => n.EventId == idEvent)
                .Select(n => new NotificationDto(n))
                .ToListAsync();
        }

        public async Task<IEnumerable<NotificationDtoGetUser>> GetNotificationsByUser(uint idUser)
        {
            await UpdateFeedback(idUser);

            return await _context.Feedbacks
                .Where(f => f.UserId == idUser)
                .Include(f => f.Notification)
                .Select(f => f.Notification).OfType<Notification>()
                .Select(n => new NotificationDtoGetUser(n))
                .ToListAsync();
        }

        public async Task<IEnumerable<NotificationDtoGetUser>> GetUnreadNotifications(uint idUser)
        {
            await UpdateFeedback(idUser);

            return await _context.Feedbacks
                .Where(f => f.UserId == idUser)
                .Include(f => f.User)
                .Where(f => f.Date >= (f.User == null ? f.Date : f.User.LastAccess))
                .Include(f => f.Notification)
                .Select(f => f.Notification).OfType<Notification>()
                .Select(n => new NotificationDtoGetUser(n))
                .ToListAsync();
        }

        private async Task UpdateFeedback(uint idUser)
        {
            var events = await _context.Attendances
                .Include(a => a.Session)
                .Where(a => a.UserId == idUser)
                .Select(a => a.Session).OfType<Session>()
                .Select(s => s.EventId)
                .Distinct().ToListAsync();

            var notifications = await _context.Notifications
                .Include(n => n.Event)
                .Where(n => (events.Contains(n.EventId)) && (n.Event != null) && (n.Event.LastNotify < n.SendDate))
                .ToListAsync();

            notifications.ForEach(notification =>
            {
                var users = GetUsersByRecipient(notification.EventId, notification.Recipient);

                users.ForEach(idUser =>
                {
                    _feedback.CreateFeedback(new FeedbackDto
                    {
                        Date = notification.SendDate,
                        NotificationId = notification.Id,
                        UserId = idUser,
                    });
                });
            });
        }

        private List<uint> GetUsersByRecipient(uint idEvent, int recipient)
        {
            return _context.Attendances
                .Include(a => a.Session)
                .Where(a => (a.Session != null) && (a.Session.EventId == idEvent))
                .Select(a => a.UserId)
                .Distinct()
                .ToList();
        }

        public async Task<IEnumerable<NotificationTypeDto>> GetAllNotificationTypes()
        {
            return await Task.Run(() => NotificationConstraints.Types.Select(nt => new NotificationTypeDto(nt)));
        }

        public async Task<IEnumerable<NotificationRecipientDto>> GetAllNotificationRecipients()
        {
            return await Task.Run(() => NotificationConstraints.Recipients.Select(nr => new NotificationRecipientDto(nr)));
        }
    }
}
