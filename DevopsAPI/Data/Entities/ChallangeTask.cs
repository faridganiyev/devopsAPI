namespace DevopsAPI.Data.Entities
{
    public class ChallangeTask : BaseEntity
    {
        public ChallangeTask()
        {
            TaskResults = new HashSet<TaskResult>();
        }
        public string Task { get; set; }
        public virtual Challange Challange { get; set; }
        public virtual ICollection<TaskResult> TaskResults { get; set;}
    }
}
