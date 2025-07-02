using Mantel.Common.Paging;
using Mantel.Course_Service.Domain.Entities;
using MediatR;

namespace Mantel.Course_Service.Application.Features.Courses.Queries
{
    public class GetAllCoursesQuery : ListQueryBase, IRequest<PagedQueryResult<Course>>
    {
    }
}
