namespace DevopsAPI.Data.Entities
{
    public class PricingOpportunities : BaseEntity
    {
        public int PricingId { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }

        public virtual Pricing Pricing { get; set; }
    }
}
