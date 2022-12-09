using Bogus;
using DevopsAPI.Data.Entities;

namespace DevopsAPI.Data.Seeders
{
    public class PricingSeeder
    {
        public List<Pricing> Pricings { get; set; }

        public PricingSeeder()
        {
            var pricingTitles = new[]
            {
                "Free",
                "Basic",
                "Pro",
                "Enterprise"
            };
            var fakePricings = new Faker<Pricing>()
                .RuleFor(p => p.Title, f => f.PickRandom(pricingTitles))
                .RuleFor(p => p.Price, f => Convert.ToInt32(f.Commerce.Price(10, 500)))
                .RuleFor(p => p.Discount, f => f.Random.Number(10, 80))
                .RuleFor(p => p.IsActive, f => true);

            Pricings = fakePricings.Generate(4);
        }
    }
}
