using DevopsAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevopsAPI.Data.EntityConfigurations
{
    public class ServiceTypeConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("service");

            builder.Property(x => x.Id)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Script)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValue(DateOnly.FromDateTime(DateTime.Now));

            builder.Property(x => x.ModifiedDate)
                .HasDefaultValue(null);

        }
    }
}
