using Mantel.Common.Data.Interfaces;
using Mantel.Course_Service.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Course_Service.Domain.Interfaces
{
    public interface ICourseRepository
    {
        Task AddAsync(Course Course);
        Task<Course?> GetByIdAsync(Guid id);
        Task<List<Course>> GetAllAsync();
        IQueryable<Course> GetAllCourses();
        Task UpdateAsync(Course grade);
        Task DeleteAsync(Guid id);
    }
}
