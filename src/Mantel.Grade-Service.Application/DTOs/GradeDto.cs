using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Grade_Service.Application.DTOs
{
    public class GradeDto
    {
        public Guid StudentId { get; private set; }
        public Guid CourseId { get; private set; }
        public double Value { get; private set; }
    }
}
