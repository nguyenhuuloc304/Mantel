using System;

namespace Mantel.Common.Data.Interfaces
{
    public interface ITracksModification
    {
        public Guid ModifiedByUserId { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}