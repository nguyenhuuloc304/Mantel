using Mantel.Common.Paging;
using Mantel.Student_Service.Domain.Entities;
using MediatR;

namespace Mantel.Student_Service.Application.Features.Students.Queries
{
    public class GetAllStudentsQuery : ListQueryBase, IRequest<PagedQueryResult<Student>>
    {
    }
}
