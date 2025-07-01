using System;

namespace Mantel.Common.Data.Interfaces
{
    public interface ITracksCreation
    {
        Guid CreatedByProfileId { get; set; }
        DateTime CreatedDate { get; set; }
    }
}