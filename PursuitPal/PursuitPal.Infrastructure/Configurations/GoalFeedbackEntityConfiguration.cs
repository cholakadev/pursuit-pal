using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PursuitPal.Infrastructure.Entities;

namespace PursuitPal.Infrastructure.Configurations
{
    public class GoalFeedbackEntityConfiguration : IEntityTypeConfiguration<GoalFeedback>
    {
        public void Configure(EntityTypeBuilder<GoalFeedback> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Feedback).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.HasOne(x => x.Goal)
                .WithMany(x => x.Feedbacks)
                .HasForeignKey(x => x.GoalId);
        }
    }
}
