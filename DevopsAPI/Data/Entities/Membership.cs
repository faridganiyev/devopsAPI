namespace DevopsAPI.Data.Entities
{
    public class Membership : BaseEntity
    {
        public Membership()
        {
            Payments = new HashSet<Payment>();
        }
        public string UserId { get; set; }
        public int PricingId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly DueDate { get; set; }
        public virtual AppUser User { get; set; }
        public virtual Pricing Pricing { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
