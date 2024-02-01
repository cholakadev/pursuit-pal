using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PursuitPal.Core.Helpers;
using PursuitPal.Infrastructure.Entities;

namespace PursuitPal.Infrastructure.Configurations
{
    public class GoalEntityConfiguration : IEntityTypeConfiguration<Goal>
    {
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FromDate).IsRequired();
            builder.Property(x => x.ToDate).IsRequired();
            builder.Property(x => x.Status).HasDefaultValue(GoalStatus.Active);
            builder.HasOne(x => x.User);
            builder.HasOne(x => x.Details);
            builder.HasMany(x => x.Feedbacks)
                .WithOne(x => x.Goal)
                .HasForeignKey(x => x.GoalId);
        }
    }
}
