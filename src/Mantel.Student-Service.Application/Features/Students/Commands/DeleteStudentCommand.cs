using Mantel.Student_Service.Application.DTOs;
using MediatR;

namespace Mantel.Student_Service.Application.Features.Students.Commands
{
    public class DeleteStudentCommand : IRequest<StudentDto>
    {
        public Guid EntityId { get; set; }
    }
}
