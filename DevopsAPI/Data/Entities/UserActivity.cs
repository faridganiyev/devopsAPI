namespace DevopsAPI.Data.Entities
{
    public class UserActivity : BaseEntity
    {
        public string Title { get; set; }
        public virtual AppUser User { get; set; }
    }
}
