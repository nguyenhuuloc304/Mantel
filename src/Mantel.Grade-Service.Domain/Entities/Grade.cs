using Mantel.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Grade_Service.Domain.Entities
{
    public class Grade : BaseEntity
    {
        public Guid StudentId { get; private set; }
        public Guid CourseId { get; private set; }
        public double Value { get; private set; }
    }
}
