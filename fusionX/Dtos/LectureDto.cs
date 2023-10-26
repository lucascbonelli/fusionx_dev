using EvenTech.Models;

public class LectureDto
{
    public uint Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime BeginDate { get; set; }
    public DateTime EndDate { get; set; }
    public uint SessionId { get; set; }
    public LectureDto(Lecture lecture)
    {
        Id = lecture.Id;
        Title = lecture.Title;
        Description = lecture.Description;
        BeginDate = lecture.BeginDate;
        EndDate = lecture.EndDate;
        SessionId = lecture.SessionId;
    }

    public LectureDto()
    {
    }
}