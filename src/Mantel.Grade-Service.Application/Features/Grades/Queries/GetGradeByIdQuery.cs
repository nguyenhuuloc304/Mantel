using Mantel.Common.Paging;
using Mantel.Grade_Service.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Grade_Service.Application.Features.Grades.Queries
{
    public class GetGradeByIdQuery : QueryBase, IRequest<Grade>
    {
        public Guid EntityId { get; set; }
    }
}