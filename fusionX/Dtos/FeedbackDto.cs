using EvenTech.Models;

namespace EvenTech.Dtos
{
    public class FeedbackDto
    {
        public uint Id { get; set; }
        public string Response { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public uint NotificationId { get; set; }
        public uint UserId { get; set; }
        public FeedbackDto() { }
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
