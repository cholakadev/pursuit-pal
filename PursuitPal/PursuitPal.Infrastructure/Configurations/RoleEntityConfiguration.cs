using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PursuitPal.Core.Enums;
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

            builder.HasData(
                new Role { Id = 1, RoleName = UserRole.SystemAdmin.ToString() },
                new Role { Id = 2, RoleName = UserRole.Admin.ToString() },
                new Role { Id = 3, RoleName = UserRole.Lead.ToString() },
                new Role { Id = 4, RoleName = UserRole.Manager.ToString() },
                new Role { Id = 5, RoleName = UserRole.Employee.ToString() });
        }
    }
}
