using Mantel.Common.Data.Interfaces;
using Mantel.Student_Service.Domain.Entities;

namespace Mantel.Student_Service.Domain.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        IQueryable<Student> GetAllStudent();
    }
}
