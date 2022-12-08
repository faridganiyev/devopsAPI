using DevopsAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevopsAPI.Data.EntityConfigurations
{
    public class QuizTicketTypeConfiguration : IEntityTypeConfiguration<QuizTicket>
    {
        public void Configure(EntityTypeBuilder<QuizTicket> builder)
        {
            builder.ToTable("quiz_ticket");

            builder.HasIndex(x=>x.No)
                .IsUnique();

            builder.Property(x => x.Id)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.No)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x=>x.Time)
                .IsRequired()
                .HasDefaultValue(60);

            builder.Property(x => x.Level)
                .HasDefaultValue(QuizLevel.normal);

            builder.Property(x=>x.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValue(DateOnly.FromDateTime(DateTime.Now));

            builder.Property(x => x.ModifiedDate)
                .HasDefaultValue(null);

            builder.HasOne(qt => qt.Category)
                .WithMany(c=>c.QuizTickets)
                .HasForeignKey(f=>f.CategoryId);
        }
    }
}
