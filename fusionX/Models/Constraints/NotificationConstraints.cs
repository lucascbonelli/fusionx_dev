namespace EvenTech.Models.Constraints
{
    public class NotificationConstraints
    {
        public static readonly ICollection<NotificationType> Types = new List<NotificationType>
        {
            new NotificationType() { Id = 1, Description = "OK" },
            new NotificationType() { Id = 2, Description = "Confirmar presença" },
            new NotificationType() { Id = 3, Description = "Sim/Não" },
            new NotificationType() { Id = 4, Description = "Texto livre" },
            new NotificationType() { Id = 5, Description = "Avaliação por palestra" },
        };

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