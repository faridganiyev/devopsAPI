using DevopsAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevopsAPI.Data.EntityConfigurations
{
    public class QuizTypeConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.ToTable("quiz");

            builder.Property(x => x.Id)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.Question)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(x=>x.Answer)
                .IsRequired()
                .HasDefaultValue(500);

            builder.Property(x => x.Explanation)
                .IsRequired()
                .HasDefaultValue(5000);

            builder.Property(x=>x.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValue(DateOnly.FromDateTime(DateTime.Now));

            builder.Property(x => x.ModifiedDate)
                .HasDefaultValue(null);

            builder.HasOne(q=>q.Ticket)
                .WithMany(t=>t.Quizzes);
        }
    }
}
