using Mantel.Course_Service.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Course_Service.Application.Features.Courses.Commands
{
    public class DeleteCourseCommand : IRequest<CourseDto>
    {
        public Guid EntityId { get; set; }
    }
}
