using Mantel.Common.Paging;
using Mantel.Grade_Service.Domain.Entities;
using MediatR;

namespace Mantel.Grade_Service.Application.Features.Grades.Queries
{
    public class GetGradeByIdQuery : QueryBase, IRequest<Grade>
    {
        public Guid EntityId { get; set; }
    }
}