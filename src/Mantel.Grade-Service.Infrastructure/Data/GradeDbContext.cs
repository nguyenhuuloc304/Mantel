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
    public class GradeDbContext : DbContext
    {
        public const string SchemaName = "Grade";
        public GradeDbContext(DbContextOptions<GradeDbContext> options) : base(options) { }

        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer("Grades");


            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToContainer("Grades");
                entity.HasPartitionKey(g => g.StudentId);
                entity.HasKey(g => g.EntityId);
                entity.Property(g => g.EntityId).ToJsonProperty("id");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
