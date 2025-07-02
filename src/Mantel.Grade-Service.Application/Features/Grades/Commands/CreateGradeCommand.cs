using Mantel.Grade_Service.Application.DTOs;
using MediatR;

namespace Mantel.Grade_Service.Application.Features.Grades.Commands
{
    public class CreateGradeCommand : IRequest<GradeDto>
    {
        public Guid EntityId { get; set; }
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public double Value { get; set; }
    }
}
