using DevopsAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevopsAPI.Data.EntityConfigurations
{
    public class TaskResultTypeConfiguration : IEntityTypeConfiguration<TaskResult>
    {
        public void Configure(EntityTypeBuilder<TaskResult> builder)
        {
            builder.ToTable("task_result");

            builder.Property(x => x.Id)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.IsCompleted)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(x=>x.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValue(DateOnly.FromDateTime(DateTime.Now));

            builder.Property(x => x.ModifiedDate)
                .HasDefaultValue(null);

            builder.HasOne(tr=>tr.ChallangeResult)
                .WithMany(cr=>cr.TaskResults);

            builder.HasOne(tr => tr.ChallangeTask)
                .WithMany(ct => ct.TaskResults);
        }
    }
}
