using Mantel.Common.Data.Interfaces;
using Mantel.Student_Service.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Student_Service.Domain.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<Student> GetById(Guid studentGuid);

        Task<List<Student>> GetByIdsAsync(List<Guid> studentGuids);

        Task<Student> CreateAsync(Student student);

        Task<List<Student>> GetAllAsync();
    }
}
