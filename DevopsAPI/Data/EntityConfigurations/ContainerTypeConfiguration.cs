using DevopsAPI.Data.Entities;
using DevopsAPI.Models;
using DevopsAPI.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevopsAPI.Data.EntityConfigurations
{
    public class ContainerTypeConfiguration : IEntityTypeConfiguration<Container>
    {
        public void Configure(EntityTypeBuilder<Container> builder)
        {
            builder.ToTable("container");

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.Property(x => x.Id)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x=>x.Type)
                .IsRequired()
                .HasDefaultValue(ContainerType.docker);

            builder.Property(x => x.Port)
                .IsRequired();

            builder.Property(x => x.Location)
                .IsRequired();

            builder.Property(x => x.LifeTime)
                .IsRequired()
                .HasDefaultValue(180);

            builder.Property(x => x.IsAlive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(x=>x.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValue(DateOnly.FromDateTime(DateTime.Now));

            builder.Property(x => x.ModifiedDate)
                .HasDefaultValue(null);
        }
    }
}
