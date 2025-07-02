using Mantel.Common.Data;
using Mantel.Student_Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mantel.Student_Service.Infrastructure.Data
{
    public class AppDbContext : BaseDbContext
    {
        public const string SchemaName = "Student";
        public AppDbContext() : base()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(SchemaName);

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student", SchemaName).HasKey(k => k.EntityId);

                entity.Property(e => e.EntityId).ValueGeneratedOnAdd();

                entity.Property(e => e.EntityId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(true);
            });
        }
    }
}