namespace EvenTech.Models.Constraints
{
    public class NotificationConstraints
    {
        public class Type
        {
            public static readonly NotificationType Ok            = new NotificationType() { Id = 1, Description = "OK" };
            public static readonly NotificationType Confirm       = new NotificationType() { Id = 2, Description = "Confirmar presença" };
            public static readonly NotificationType YesNo         = new NotificationType() { Id = 3, Description = "Sim/Não" };
            public static readonly NotificationType FreeText      = new NotificationType() { Id = 4, Description = "Texto livre" };
            public static readonly NotificationType LectureRating = new NotificationType() { Id = 5, Description = "Avaliação por palestra" };
        }
        public static readonly ICollection<NotificationType> Types = new List<NotificationType>
        {
            Type.Ok, Type.Confirm, Type.YesNo, Type.FreeText, Type.LectureRating
        };
        public static readonly int[] OverviewTypeIds = { 3, 4, 5 };

        public static readonly ICollection<NotificationRecipient> Recipients = new List<NotificationRecipient>
        {
            new NotificationRecipient() { Id = 1, Description = "Todos" },
            new NotificationRecipient() { Id = 2, Description = "Presentes" },
            new NotificationRecipient() { Id = 3, Description = "Ausentes - Todos" },
            new NotificationRecipient() { Id = 4, Description = "Ausentes - Cancelados" },
            new NotificationRecipient() { Id = 5, Description = "Ausentes - Sem feedback" },
        };
    }
}