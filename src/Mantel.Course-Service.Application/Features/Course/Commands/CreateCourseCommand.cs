using Mantel.Course_Service.Application.DTOs;
using MediatR;

namespace Mantel.Course_Service.Application.Features.Courses.Commands
{
    public class CreateCourseCommand : IRequest<CourseDto>
    {
        public Guid EntityId { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }
    }
}
