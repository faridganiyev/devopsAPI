namespace DevopsAPI.Data.Entities
{
    public class ChallangeResult : BaseEntity
    {
        public ChallangeResult()
        {
            TaskResults = new HashSet<TaskResult>();
        }
        public int Score { get; set; }
        public int IsCompleted { get; set; }
        public virtual AppUser User { get; set; }
        public virtual Challange Challange { get; set; }
        public virtual ICollection<TaskResult> TaskResults { get; set; }
    }
}
