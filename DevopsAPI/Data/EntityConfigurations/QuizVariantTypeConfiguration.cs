using DevopsAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevopsAPI.Data.EntityConfigurations
{
    public class QuizVariantTypeConfiguration : IEntityTypeConfiguration<QuizVariant>
    {
        public void Configure(EntityTypeBuilder<QuizVariant> builder)
        {
            builder.ToTable("quiz_variant");

            builder.Property(x => x.Id)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.Variant)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x=>x.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValue(DateOnly.FromDateTime(DateTime.Now));

            builder.Property(x => x.ModifiedDate)
                .HasDefaultValue(null);

            builder.HasOne(qv=>qv.Quiz)
                .WithMany(q=>q.Variants);
        }
    }
}
