using Mantel.Course_Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Course_Service.Infrastructure.Data
{
    public class CourseDbContext : DbContext
    {
        public const string SchemaName = "Course";
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer("Courses");


            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToContainer("Courses");
                //entity.HasPartitionKey(g => g.StudentId);
                entity.HasKey(g => g.EntityId);
                entity.Property(g => g.EntityId).ToJsonProperty("id");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
