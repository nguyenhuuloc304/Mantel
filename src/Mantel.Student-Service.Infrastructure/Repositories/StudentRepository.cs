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

        public async Task<List<Student>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }

        public override IQueryable<Student> GetAll()
        {
            return base.GetAll();
        }

        public async Task<Student> CreateAsync(Student student)
        {
            var created = await Add(student);
            await Save();
            return created;
        }
    }
}
