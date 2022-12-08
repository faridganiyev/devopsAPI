using DevopsAPI.Data.Entities;
using DevopsAPI.Data.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevopsAPI.Data.EntityConfigurations
{
    public class AppUserTypeConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("user");

            var userSeeding = new AppUserSeeding();

            builder.HasData(userSeeding.AppUsers);
        }
    }
}
