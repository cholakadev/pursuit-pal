using Microsoft.EntityFrameworkCore;
using PursuitPal.Core.Extensions;
using PursuitPal.Infrastructure.Configurations;
using PursuitPal.Infrastructure.Entities;

namespace PursuitPal.Infrastructure
{
    public class PursuitPalDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Goal> Goals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new GoalEntityConfiguration());
            modelBuilder.ApplyConfiguration(new GoalDetailsEntityConfiguration());
            modelBuilder.ApplyConfiguration(new GoalFeedbackEntityConfiguration());
        }

        // TODO: Get the actual user ID from the http context
        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var addedEntities = ChangeTracker.Entries<Auditable>().Where(x => x.IsAdded());
            var modifiedEntities = ChangeTracker.Entries<Auditable>().Where(x => x.IsModified());

            foreach (var entry in addedEntities)
            {
                entry.CurrentValues[nameof(Auditable.CreatedAt)] = DateTime.Now;
                entry.CurrentValues[nameof(Auditable.UpdatedBy)] = Guid.NewGuid();
            }

            foreach (var entry in modifiedEntities)
            {
                entry.CurrentValues[nameof(Auditable.UpdatedAt)] = DateTime.Now;
                entry.CurrentValues[nameof(Auditable.UpdatedBy)] = Guid.NewGuid();
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
