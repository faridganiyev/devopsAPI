namespace DevopsAPI.Data.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateOnly CreatedDate { get; set; }
        public DateOnly ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
