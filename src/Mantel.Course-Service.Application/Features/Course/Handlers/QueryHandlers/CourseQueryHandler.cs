using Mantel.Common.Paging;
using Mantel.Course_Service.Application.Features.Courses.Queries;
using Mantel.Course_Service.Domain.Entities;
using Mantel.Course_Service.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Course_Service.Application.Features.Courses.Handlers.QueryHandlers
{
    public class CourseQueryHandler :
        IRequestHandler<GetAllCoursesQuery, PagedQueryResult<Course>>,
        IRequestHandler<GetCourseByIdQuery, Course>
    {
        private readonly ICourseRepository _courseRepo;

        public CourseQueryHandler(ICourseRepository curseRepo)
        {
            _courseRepo = curseRepo;
        }

        public async Task<PagedQueryResult<Course>> Handle(GetAllCoursesQuery query, CancellationToken cancellationToken)
        {
            var dataQueryable = _courseRepo.GetAllCourses();
            var data = await dataQueryable.Skip((query.Page - 1) * query.PageSize)
                                    .Take(query.PageSize)
                                    .ToListAsync();
            var totalItemCount = dataQueryable.Count();

            return new PagedQueryResult<Course>(data, totalItemCount, query.Page, query.PageSize);
        }

        public async Task<Course> Handle(GetCourseByIdQuery query, CancellationToken cancellationToken)
        {
            return await _courseRepo.GetByIdAsync(query.EntityId);
        }
    }
}
