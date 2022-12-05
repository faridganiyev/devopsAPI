namespace DevopsAPI.Data.Entities
{
    public class TaskResult : BaseEntity
    {
        public bool IsCompleted { get; set; }
        public virtual ChallangeTask ChallangeTask { get; set; }
        public virtual ChallangeResult ChallangeResult { get; set; }
    }
}
