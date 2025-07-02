using Mantel.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Course_Service.Domain.Entities
{
    public class Course : BaseEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Credit { get; private set; }
    }
}
