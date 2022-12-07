using DevopsAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevopsAPI.Data.EntityConfigurations
{
    public class PricingOpportunitiesTypeConfiguration : IEntityTypeConfiguration<PricingOpportunities>
    {
        public void Configure(EntityTypeBuilder<PricingOpportunities> builder)
        {
            builder.ToTable("pricing");

            builder.Property(x => x.Id)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Value)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(x=>x.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValue(DateOnly.FromDateTime(DateTime.Now));

            builder.Property(x => x.ModifiedDate)
                .HasDefaultValue(null);

            builder.HasOne(po => po.Pricing)
                .WithMany(p => p.Opportunities);
        }
    }
}
