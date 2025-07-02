using Mantel.Course_Service.Domain.Entities;
using Mantel.Course_Service.Domain.Interfaces;
using Mantel.Course_Service.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Course_Service.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseDbContext _context;

        public CourseRepository(CourseDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Course Course)
        {
            await _context.Courses.AddAsync(Course);
            await _context.SaveChangesAsync();
        }

        public async Task<Course?> GetByIdAsync(Guid id)
        {
            return await _context.Courses
                .FirstOrDefaultAsync(g => g.EntityId == id);
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public IQueryable<Course> GetAllCourses()
        {
            var dataQuery = _context.Courses.AsQueryable();
            return dataQuery;
        }

        public async Task UpdateAsync(Course Course)
        {
            var existing = await _context.Courses
                .FirstOrDefaultAsync(g => g.EntityId == Course.EntityId);

            if (existing is null)
                throw new KeyNotFoundException("Course not found");

            //existing.UpdateValue(Course.Value);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var Course = await _context.Courses
                .FirstOrDefaultAsync(g => g.EntityId == id);

            if (Course is null)
                throw new KeyNotFoundException("Course not found");

            _context.Courses.Remove(Course);
            await _context.SaveChangesAsync();
        }
    }
}
