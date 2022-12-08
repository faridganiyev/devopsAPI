using DevopsAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevopsAPI.Data.EntityConfigurations
{
    public class PaymentTypeConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("payment");

            builder.Property(x => x.Id)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.Method)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Note)
                .HasMaxLength(255);

            builder.Property(x => x.Value)
                .IsRequired();

            builder.Property(x=>x.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValue(DateOnly.FromDateTime(DateTime.Now));

            builder.Property(x => x.ModifiedDate)
                .HasDefaultValue(null);

            builder.HasOne(p => p.Membership)
                .WithMany(m=>m.Payments)
                .HasForeignKey(f=>f.MembershipId);

            builder.HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .HasForeignKey(f=>f.UserId);
        }
    }
}
