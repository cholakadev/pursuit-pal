using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PursuitPal.Core.Helpers;
using PursuitPal.Infrastructure.Entities;

namespace PursuitPal.Infrastructure.Configurations
{
    public class GoalFeedbackEntityConfiguration : IEntityTypeConfiguration<GoalFeedback>
    {
        public void Configure(EntityTypeBuilder<GoalFeedback> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Feedback).IsRequired().HasMaxLength(1000);
            builder.HasOne(x => x.Goal);
        }
    }
}
