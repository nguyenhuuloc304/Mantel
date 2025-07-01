using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Common.Enums
{
    public enum ReturnStatus
    {
        OK = 0,
        MultipleRecordsUpdated = 1,
        Error = 2,
        NotFound = 3,
        BadRequest = 4,
        Unauthorized = 5,
        Forbidden = 6,
        MethodNotAllowed = 7,
        Conflict = 8
    }
}
