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
        public string Name { get; set; }
        public int Credit { get; set; }


        public void UpdateValue(int newCredit)
        {
            Credit = newCredit;
        }
    }
}
