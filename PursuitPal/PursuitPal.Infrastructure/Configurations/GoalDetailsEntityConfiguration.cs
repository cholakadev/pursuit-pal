using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PursuitPal.Infrastructure.Entities;

namespace PursuitPal.Infrastructure.Configurations
{
    public class GoalDetailsEntityConfiguration : IEntityTypeConfiguration<GoalDetails>
    {
        public void Configure(EntityTypeBuilder<GoalDetails> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.CompletionCriteria).IsRequired().HasMaxLength(200);
            builder.HasOne(x => x.Goal);
        }
    }
}
