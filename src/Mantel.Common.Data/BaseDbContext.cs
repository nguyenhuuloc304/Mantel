using Mantel.Common.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Common.Data
{
    public abstract class BaseDbContext : DbContext
    {
        protected BaseDbContext(bool applyGlobalIsDeleteQueryFilter = true)
        {
        }

        protected BaseDbContext(DbContextOptions options, bool applyGlobalIsDeleteQueryFilter = true)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
            => SaveChangesAsync(acceptAllChangesOnSuccess: true, cancellationToken: cancellationToken);

        public override int SaveChanges() => SaveChanges(acceptAllChangesOnSuccess: true);

        public override async Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            SetAutomaticModelMetadata();

            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            SetAutomaticModelMetadata();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        private void SetAutomaticModelMetadata()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted));

            var now = DateTime.UtcNow;

            foreach (var entry in modifiedEntries)
            {
                if (entry.Entity is IHasSoftDelete deletedEntity && entry.State == EntityState.Deleted)
                {
                    // If an entity that is 'soft deletable' is removed from a set, change it to a soft delete
                    entry.State = EntityState.Modified;
                    deletedEntity.IsDeleted = true;
                }

                if (entry.Entity is ITracksCreation createdEntity && entry.State == EntityState.Added)
                {
                    createdEntity.CreatedDate = now;
                }

                if (entry.Entity is ITracksModification modifiedEntity)
                {
                    modifiedEntity.ModifiedDate = now;
                }
            }
        }

    }
}
