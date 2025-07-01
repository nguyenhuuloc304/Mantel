using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Common.Data.Interfaces
{
    public interface IEntity
    {
        Guid EntityId { get; set; }
    }
}
