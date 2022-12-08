namespace DevopsAPI.Data.Entities
{
    public class UserInfo : BaseEntity
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string? Address { get; set; }
        public string? Picture { get; set; }

        public virtual AppUser User { get; set; }
    }

    public enum Gender
    {
        male,
        female,
        other
    }
}
