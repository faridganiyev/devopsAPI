namespace DevopsAPI.Data.Entities
{
    public class TaskResult : BaseEntity
    {
        public int ChallangeResultId { get; set; }
        public int TaskId { get; set; }
        public bool IsCompleted { get; set; }
        public virtual ChallangeTask ChallangeTask { get; set; }
        public virtual ChallangeResult ChallangeResult { get; set; }
    }
}
