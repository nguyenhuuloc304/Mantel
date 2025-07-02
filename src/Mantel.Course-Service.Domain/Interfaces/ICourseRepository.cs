using Mantel.Common.Data.Interfaces;
using Mantel.Course_Service.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Course_Service.Domain.Interfaces
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        IQueryable<Course> GetAllCourses();
    }
}
