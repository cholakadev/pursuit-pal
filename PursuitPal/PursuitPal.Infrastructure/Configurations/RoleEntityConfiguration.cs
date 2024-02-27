using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PursuitPal.Core.Helpers;
using PursuitPal.Infrastructure.Entities;

namespace PursuitPal.Infrastructure.Configurations
{
    public class RoleEntityConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.CreatedBy).HasDefaultValue(new Guid(ApplicationConstants.SystemGuid));
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.HasMany(x => x.Users)
                .WithMany(x => x.Roles)
                .UsingEntity(j => j.ToTable("UserRoles"));

            builder.HasData(
                new Role { Id = 1, RoleName = "SystemAdmin" },
                new Role { Id = 2, RoleName = "Admin" },
                new Role { Id = 3, RoleName = "Lead" },
                new Role { Id = 4, RoleName = "Manager" },
                new Role { Id = 5, RoleName = "Employee" });
        }
    }
}
