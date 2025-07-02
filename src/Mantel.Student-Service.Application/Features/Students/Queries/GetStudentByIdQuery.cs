using Mantel.Common.Paging;
using Mantel.Student_Service.Domain.Entities;
using MediatR;

namespace Mantel.Student_Service.Application.Features.Students.Queries
{
    public class GetStudentByIdQuery : QueryBase, IRequest<Student>
    {
        public Guid EntityId { get; set; }
    }
}