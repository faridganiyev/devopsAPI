using DevopsAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevopsAPI.Data.EntityConfigurations
{
    public class ChallangeTicketTypeConfiguration : IEntityTypeConfiguration<ChallangeTicket>
    {
        public void Configure(EntityTypeBuilder<ChallangeTicket> builder)
        {
            builder.ToTable("challange_ticket");

            builder.Property(x => x.Id)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.No)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x=>x.Time)
                .IsRequired()
                .HasDefaultValue(60);

            builder.Property(x => x.Level)
                .IsRequired()
                .HasDefaultValue(QuizLevel.normal);


            builder.Property(x=>x.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValue(DateOnly.FromDateTime(DateTime.Now));

            builder.Property(x => x.ModifiedDate)
                .HasDefaultValue(null);

            builder.HasOne(ct => ct.Category)
                .WithMany(c=>c.ChallangeTickets);
        }
    }
}
