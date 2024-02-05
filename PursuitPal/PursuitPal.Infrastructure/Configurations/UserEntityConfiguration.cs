using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PursuitPal.Infrastructure.Entities;

namespace PursuitPal.Infrastructure.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Password).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Salt).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Position).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.HasMany(x => x.Goals)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .UsingEntity(j => j.ToTable("UserRoles"));
        }
    }
}
