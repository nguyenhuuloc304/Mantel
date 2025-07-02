using Mantel.Grade_Service.Domain.Entities;
using Mantel.Grade_Service.Domain.Interfaces;
using Mantel.Grade_Service.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Mantel.Grade_Service.Infrastructure.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly GradeDbContext _context;

        public GradeRepository(GradeDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Grade grade)
        {
            await _context.Grades.AddAsync(grade);
            await _context.SaveChangesAsync();
        }

        public async Task<Grade?> GetByIdAsync(Guid id)
        {
            return await _context.Grades
                .FirstOrDefaultAsync(g => g.EntityId == id);
        }

        public async Task<List<Grade>> GetByStudentIdAsync(Guid studentId)
        {
            return await _context.Grades
                .Where(g => g.StudentId == studentId)
                .ToListAsync();
        }

        public async Task<List<Grade>> GetAllAsync()
        {
            return await _context.Grades.ToListAsync();
        }

        public IQueryable<Grade> GetAllGrades()
        {
            var dataQuery = _context.Grades.AsQueryable();
            return dataQuery;
        }

        public async Task UpdateAsync(Grade grade)
        {
            var existing = await _context.Grades
                .FirstOrDefaultAsync(g => g.EntityId == grade.EntityId);

            if (existing is null)
                throw new KeyNotFoundException("Grade not found");

            existing.UpdateValue(grade.Value);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var grade = await _context.Grades
                .FirstOrDefaultAsync(g => g.EntityId == id);

            if (grade is null)
                throw new KeyNotFoundException("Grade not found");

            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
        }
    }
}
