namespace DevopsAPI.Data.Entities
{
    public class Quiz : BaseEntity
    {
        public Quiz()
        {
            Variants = new HashSet<QuizVariant>();
            Results = new HashSet<QuizResult>();
        }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string? Explanation { get; set; }

        public virtual QuizTicket Ticket { get; set; }
        public virtual ICollection<QuizVariant> Variants { get; set; }
        public virtual ICollection<QuizResult> Results { get; set; }
    }
}
