using Mantel.Common.Data.Interfaces;
using Mantel.Grade_Service.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Grade_Service.Domain.Interfaces
{
    public interface IGradeRepository : IBaseRepository<Grade>
    {
        IQueryable<Grade> GetAllGrades();
    }
}
