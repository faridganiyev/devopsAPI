using DevopsAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevopsAPI.Data.EntityConfigurations
{
    public class ChallangeResultTypeConfiguration : IEntityTypeConfiguration<ChallangeResult>
    {
        public void Configure(EntityTypeBuilder<ChallangeResult> builder)
        {
            builder.ToTable("challange_result");

            builder.Property(x => x.Id)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.Score)
                .IsRequired();

            builder.Property(x => x.IsCompleted)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(x=>x.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValue(DateOnly.FromDateTime(DateTime.Now));

            builder.Property(x => x.ModifiedDate)
                .HasDefaultValue(null);

            builder.HasOne(cr=>cr.Challange)
                .WithMany(c=>c.Results)
                .HasForeignKey(f => f.ChallangeId);

            builder.HasOne(cr => cr.User)
                .WithMany(u => u.ChallangeResults)
                .HasForeignKey(f=>f.UserId);
        }
    }
}
