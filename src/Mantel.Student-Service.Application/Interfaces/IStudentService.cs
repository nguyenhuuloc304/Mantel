using Mantel.Student_Service.Application.DTOs;
using Mantel.Student_Service.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Student_Service.Application.Interfaces
{
    public interface IStudentService
    {
        Task<Student> GetAStudent(Guid studentGuid);

        Task<List<Student>> GetAllStudents();

        Task<Student> CreateAStudent(CreateStudentRequestDto student);
    }
}
