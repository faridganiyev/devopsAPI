using DevopsAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevopsAPI.Data.EntityConfigurations
{
    public class ChallangeTypeConfiguration : IEntityTypeConfiguration<Challange>
    {
        public void Configure(EntityTypeBuilder<Challange> builder)
        {
            builder.ToTable("challange");

            builder.Property(x => x.Id)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(x=>x.Solution)
                .IsRequired()
                .HasDefaultValue(500);

            builder.Property(x=>x.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValue(DateOnly.FromDateTime(DateTime.Now));

            builder.Property(x => x.ModifiedDate)
                .HasDefaultValue(null);

            builder.HasOne(ch=>ch.Ticket)
                .WithMany(t=>t.Challanges)
                .HasForeignKey(f=>f.TicketId);
        }
    }
}
