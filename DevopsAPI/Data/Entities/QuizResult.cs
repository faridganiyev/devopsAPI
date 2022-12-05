namespace DevopsAPI.Data.Entities
{
    public class QuizResult : BaseEntity
    {
        public int Score { get; set; }
        public int IsCompleted { get; set; }
        public virtual AppUser User { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
