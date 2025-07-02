using Mantel.Student_Service.Application.DTOs;
using MediatR;

namespace Mantel.Student_Service.Application.Features.Students.Commands
{
    public class CreateStudentCommand : IRequest<StudentDto>
    {
        public Guid EntityId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
