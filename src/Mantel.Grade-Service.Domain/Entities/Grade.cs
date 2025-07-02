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
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public double Value { get; set; }

        private Grade() { }

        public void UpdateValue(double newValue)
        {
            Value = newValue;
        }
    }
}
