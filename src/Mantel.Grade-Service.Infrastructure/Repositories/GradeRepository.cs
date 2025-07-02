using Mantel.Common.Data;
using Mantel.Grade_Service.Domain.Entities;
using Mantel.Grade_Service.Domain.Interfaces;
using Mantel.Grade_Service.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Grade_Service.Infrastructure.Repositories
{
    public class GradeRepository : BaseRepository<AppDbContext, Grade>, IGradeRepository
    {
        public GradeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Grade> GetByIdAsync(Guid studentGuid)
        {
            return await Context.Grades.FindAsync(studentGuid);
        }

        public IQueryable<Grade> GetAllGrades()
        {
            var dataQuery = Context.Grades.AsQueryable();
            return dataQuery;
        }

        public Task<Grade> GetById(Guid studentGuid)
        {
            throw new NotImplementedException();
        }

        public Task<List<Grade>> GetByIdsAsync(List<Guid> studentGuids)
        {
            throw new NotImplementedException();
        }
    }
}
