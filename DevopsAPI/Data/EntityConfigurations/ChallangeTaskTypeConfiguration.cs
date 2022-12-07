using DevopsAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevopsAPI.Data.EntityConfigurations
{
    public class ChallangeTaskTypeConfiguration : IEntityTypeConfiguration<ChallangeTask>
    {
        public void Configure(EntityTypeBuilder<ChallangeTask> builder)
        {
            builder.ToTable("challange_task");

            builder.Property(x => x.Id)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.Task)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(x=>x.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValue(DateOnly.FromDateTime(DateTime.Now));

            builder.Property(x => x.ModifiedDate)
                .HasDefaultValue(null);

            builder.HasOne(ct=>ct.Challange)
                .WithMany(c=>c.Tasks);
        }
    }
}
