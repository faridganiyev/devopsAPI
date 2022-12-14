namespace DevopsAPI.Data.Entities
{
    public class Payment : BaseEntity
    {
        public string UserId { get; set; }
        public int MembershipId { get; set; }
        public decimal Value { get; set; }
        public string Method { get; set; }
        public string Note { get; set; }

        public virtual AppUser User { get; set; }
        public virtual Membership Membership { get; set; }
    }
}
