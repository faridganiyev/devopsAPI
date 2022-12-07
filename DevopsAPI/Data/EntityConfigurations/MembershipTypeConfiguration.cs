using DevopsAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevopsAPI.Data.EntityConfigurations
{
    public class MembershipTypeConfiguration : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.ToTable("membership");

            builder.Property(x => x.Id)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.StartDate)
                .IsRequired()
                .HasDefaultValue(DateOnly.FromDateTime(DateTime.Now));

            builder.Property(x=>x.DueDate)
                .IsRequired()
                .HasDefaultValue(DateOnly.FromDateTime(DateTime.Now.AddYears(1)));

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValue(DateOnly.FromDateTime(DateTime.Now));

            builder.Property(x => x.ModifiedDate)
                .HasDefaultValue(null);

            builder.HasOne(m => m.User)
                .WithOne(u => u.Membership);

            builder.HasOne(m => m.Pricing)
                .WithMany(p => p.Memberships);
        }
    }
}
