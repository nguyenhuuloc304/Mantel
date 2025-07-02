using Mantel.Common.Paging;
using Mantel.Grade_Service.Domain.Entities;
using MediatR;

namespace Mantel.Grade_Service.Application.Features.Grades.Queries
{
    public class GetAllGradesQuery : ListQueryBase, IRequest<PagedQueryResult<Grade>>
    {
    }
}
