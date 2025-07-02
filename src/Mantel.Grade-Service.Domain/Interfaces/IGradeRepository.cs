using Mantel.Grade_Service.Domain.Entities;

namespace Mantel.Grade_Service.Domain.Interfaces
{
    public interface IGradeRepository
    {
        Task AddAsync(Grade grade);
        Task<Grade?> GetByIdAsync(Guid id);
        Task<List<Grade>> GetByStudentIdAsync(Guid studentId);
        Task<List<Grade>> GetAllAsync();
        IQueryable<Grade> GetAllGrades();
        Task UpdateAsync(Grade grade);
        Task DeleteAsync(Guid id);
    }
}
