namespace DevopsAPI.Data.Entities
{
    public class QuizTicket : BaseEntity
    {
        public QuizTicket()
        {
            Quizzes = new HashSet<Quiz>();
            QuizResults = new HashSet<QuizResult>();
        }
        public int CategoryId { get; set; }
        public int Time { get; set; }
        public string No { get; set; }
        public QuizLevel Level { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
        public virtual ICollection<QuizResult> QuizResults { get; set; }
    }

    public enum QuizLevel
    {
        easy,
        normal,
        hard,
        veryHard,
        pro,
        expert
    }
}
