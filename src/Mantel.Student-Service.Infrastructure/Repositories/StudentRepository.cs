using Mantel.Common.Data;
using Mantel.Student_Service.Domain.Entities;
using Mantel.Student_Service.Domain.Interfaces;
using Mantel.Student_Service.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Student_Service.Infrastructure.Repositories
{
    public class StudentRepository : BaseRepository<AppDbContext, Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Student> GetByIdAsync(Guid studentGuid)
        {
            return await Context.Students.FindAsync(studentGuid);
        }

        public IQueryable<Student> GetAllStudent()
        {
            var dataQuery = Context.Students.AsQueryable();
            return dataQuery;
        }

        public Task<Student> GetById(Guid studentGuid)
        {
            throw new NotImplementedException();
        }

        public Task<List<Student>> GetByIdsAsync(List<Guid> studentGuids)
        {
            throw new NotImplementedException();
        }
    }
}
