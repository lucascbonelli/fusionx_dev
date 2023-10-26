using EvenTech.Dtos;

namespace EvenTech.Services.Interfaces
{
    public interface INotificationService
    {
        Task<NotificationDto?> GetNotificationByIdAsync(uint id);
        Task CreateNotificationAsync(NotificationDtoInsert request);
        Task UpdateNotificationAsync(uint id, NotificationDtoUpdate request);
        Task DeleteNotificationAsync(uint id);

        Task<uint?> GetUserIdByNotification(uint id);
        Task<IEnumerable<NotificationDto>> GetNotificationsByEvent(uint idEvent);
        Task<IEnumerable<NotificationDtoGetUser>> GetNotificationsByUser(uint idUser);
        Task<IEnumerable<NotificationDtoGetUser>> GetUnreadNotifications(uint idUser);

        Task<IEnumerable<NotificationTypeDto>> GetAllNotificationTypes();
        Task<IEnumerable<NotificationRecipientDto>> GetAllNotificationRecipients();
    }
}
