using Mantel.Common.Data;
using Mantel.Grade_Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Grade_Service.Infrastructure.Data
{
    public class AppDbContext : BaseDbContext
    {
        public const string SchemaName = "Grade";
        public AppDbContext() : base()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(SchemaName);

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("Grade", SchemaName).HasKey(k => k.EntityId);

                entity.Property(e => e.EntityId).ValueGeneratedOnAdd();

                entity.Property(e => e.EntityId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(true);
            });

        }
    }
}
