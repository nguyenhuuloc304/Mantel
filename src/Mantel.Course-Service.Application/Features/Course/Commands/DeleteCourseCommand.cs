using Mantel.Course_Service.Application.DTOs;
using MediatR;

namespace Mantel.Course_Service.Application.Features.Courses.Commands
{
    public class DeleteCourseCommand : IRequest<CourseDto>
    {
        public Guid EntityId { get; set; }
    }
}
