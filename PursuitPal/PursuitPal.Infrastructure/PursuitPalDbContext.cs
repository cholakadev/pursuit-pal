using Microsoft.EntityFrameworkCore;
using PursuitPal.Core.Contracts.Services;
using PursuitPal.Core.Extensions;
using PursuitPal.Core.Helpers;
using PursuitPal.Infrastructure.Configurations;
using PursuitPal.Infrastructure.Entities;

namespace PursuitPal.Infrastructure
{
    public class PursuitPalDbContext : DbContext
    {
        private readonly IUsersContextService _usersContext;

        public PursuitPalDbContext(
            DbContextOptions<PursuitPalDbContext> options,
            IUsersContextService usersContext)
            : base(options)
        {
            _usersContext = usersContext ?? throw new ArgumentNullException(nameof(usersContext));
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Goal> Goals { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new GoalEntityConfiguration());
            modelBuilder.ApplyConfiguration(new GoalDetailsEntityConfiguration());
            modelBuilder.ApplyConfiguration(new GoalFeedbackEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RoleEntityConfiguration());
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var addedEntities = ChangeTracker.Entries<Auditable>().Where(x => x.IsAdded());
            var modifiedEntities = ChangeTracker.Entries<Auditable>().Where(x => x.IsModified());

            foreach (var entry in addedEntities)
            {
                entry.CurrentValues[nameof(Auditable.CreatedAt)] = DateTime.Now;
                entry.CurrentValues[nameof(Auditable.CreatedBy)] = _usersContext.UserId == Guid.Empty
                    ? new Guid(ApplicationConstants.SystemGuid)
                    : _usersContext.UserId;
            }

            foreach (var entry in modifiedEntities)
            {
                entry.CurrentValues[nameof(Auditable.UpdatedAt)] = DateTime.Now;
                entry.CurrentValues[nameof(Auditable.UpdatedBy)] = _usersContext.UserId == Guid.Empty
                    ? new Guid(ApplicationConstants.SystemGuid)
                    : _usersContext.UserId;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
