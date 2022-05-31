using AnalizerDashboard.Infrastructure.Repository.Interfaces;
using AnalizerDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace AnalizerDashboard.Infrastructure
{
    public class AnalizerDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Analist> Analist { get; set; }
        public DbSet<Sample> Sample { get; set; }

        public AnalizerDbContext(DbContextOptions<AnalizerDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

		public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("CreatedAt").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("CreatedAt").IsModified = false;
            }

            return await base.SaveChangesAsync() > 0;
        }

        public bool Rollback() => false;
    }
}
