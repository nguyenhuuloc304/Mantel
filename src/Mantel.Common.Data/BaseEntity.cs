using Mantel.Common.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Common.Data
{
    public abstract class BaseEntity : IEntity, IHasSoftDelete, ITracksCreation, ITracksModification
    {
        public Guid EntityId { get; set; }
        public Guid CreatedByProfileId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid ModifiedByUserId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }

        [Timestamp]
        public byte[]? TimeStamp { get; set; }
    }
}
