using DevopsAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevopsAPI.Data.EntityConfigurations
{
    public class CommandTypeConfiguration : IEntityTypeConfiguration<Command>
    {
        public void Configure(EntityTypeBuilder<Command> builder)
        {
            builder.ToTable("command");

            builder.Property(x => x.Id)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.CommandText)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValue(DateOnly.FromDateTime(DateTime.Now));

            builder.Property(x => x.ModifiedDate)
                .HasDefaultValue(null);

            builder.HasOne(cmd => cmd.Container)
                .WithMany(c => c.Commands)
                .HasForeignKey(c => c.Id);
        }
    }
}
