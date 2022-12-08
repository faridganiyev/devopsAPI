namespace DevopsAPI.Data.Entities
{
    public class QuizResult : BaseEntity
    {
        public string UserId { get; set; }
        public int TicketId { get; set; }
        public int Score { get; set; }
        public int IsCompleted { get; set; }
        public virtual AppUser User { get; set; }
        public virtual QuizTicket QuizTicket { get; set; }
    }
}
