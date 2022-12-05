namespace DevopsAPI.Data.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            QuizTickets = new HashSet<QuizTicket>();
            ChallangeTickets = new HashSet<ChallangeTicket>();
        }
        public string Title { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<QuizTicket> QuizTickets { get; set; }
        public virtual ICollection<ChallangeTicket> ChallangeTickets { get; set; }
    }
}
