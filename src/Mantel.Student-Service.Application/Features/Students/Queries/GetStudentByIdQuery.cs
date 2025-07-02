using Mantel.Common.Paging;
using Mantel.Student_Service.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Student_Service.Application.Features.Students.Queries
{
    public class GetStudentByIdQuery : QueryBase, IRequest<Student>
    {
        public Guid EntityId { get; set; }
    }
}