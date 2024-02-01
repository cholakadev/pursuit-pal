using Microsoft.EntityFrameworkCore;
using PursuitPal.Infrastructure.Entities;

namespace PursuitPal.Infrastructure
{
    public class PursuitPalDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Goal> Goals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
