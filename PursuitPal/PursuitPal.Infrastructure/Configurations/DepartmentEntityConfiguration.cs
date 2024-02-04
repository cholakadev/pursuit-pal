using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PursuitPal.Core.Helpers;
using PursuitPal.Infrastructure.Entities;

namespace PursuitPal.Infrastructure.Configurations
{
    public class DepartmentEntityConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.CreatedBy).HasDefaultValue(new Guid(ApplicationConstants.SystemGuid));
            builder.HasMany(x => x.Users)
                .WithOne(x => x.Department);

            builder.HasData(
                new Department { Id = 1, Name = "Cybersecurity" },
                new Department { Id = 2, Name = "Quality Assurance", NameShort = "QA" },
                new Department { Id = 3, Name = "Network Administration", NameShort = "NetAdmin" },
                new Department { Id = 4, Name = "Information Technology Support", NameShort = "IT Support" },
                new Department { Id = 5, Name = "Software Development", NameShort = "Dev" },
                new Department { Id = 6, Name = "Research and Development", NameShort = "R&D" },
                new Department { Id = 7, Name = "Database Management", NameShort = "DB" },
                new Department { Id = 8, Name = "User Experience", NameShort = "UX" },
                new Department { Id = 9, Name = "Infrastructure and Cloud", NameShort = "DevOps" },
                new Department { Id = 10, Name = "Systems Administration", NameShort = "SysAdmin" },
                new Department { Id = 11, Name = "Business Intelligence", NameShort = "BI" },
                new Department { Id = 12, Name = "Customer Support" },
                new Department { Id = 13, Name = "Sales and Marketing" },
                new Department { Id = 14, Name = "Human Resources", NameShort = "HR" },
                new Department { Id = 15, Name = "Finance and Accounting" },
                new Department { Id = 16, Name = "Legal and Compliance" });
        }
    }
}
