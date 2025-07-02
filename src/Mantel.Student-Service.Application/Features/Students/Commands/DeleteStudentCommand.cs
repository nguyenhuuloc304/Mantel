using Mantel.Student_Service.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Student_Service.Application.Features.Students.Commands
{
    public class DeleteStudentCommand : IRequest<StudentDto>
    {
        public Guid EntityId { get; set; }
    }
}
