using hackweek_backend.Models;

namespace hackweek_backend.dtos
{
    public class FeedbackDto
    {
        public uint Id { get; set; }
        public string Response { get; set; }
        public DateTime Date { get; set; }
        public uint NotificationId { get; set; }
        public uint UserId { get; set; }
        public FeedbackDto(Feedback feedback)
        {
            Id = feedback.Id;
            Response = feedback.Response;
            Date = feedback.Date;
            NotificationId = feedback.NotificationId;
            UserId = feedback.UserId;
        }
    }
}
