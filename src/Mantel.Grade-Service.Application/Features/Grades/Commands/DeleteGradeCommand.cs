using Mantel.Grade_Service.Application.DTOs;
using MediatR;

namespace Mantel.Grade_Service.Application.Features.Grades.Commands
{
    public class DeleteGradeCommand : IRequest<GradeDto>
    {
        public Guid EntityId { get; set; }
    }
}
