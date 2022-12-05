namespace DevopsAPI.Data.Entities
{
    public class Pricing : BaseEntity
    {
        public Pricing()
        {
            Memberships = new HashSet<Membership>();
            Opportunities = new HashSet<PricingOpportunities>();
        }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
        public virtual ICollection<PricingOpportunities> Opportunities { get; set; }
    }
}
