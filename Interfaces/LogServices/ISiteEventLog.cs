using System;

namespace DSM.Core.Interfaces.LogServices
{
    public interface ISiteEventLog
    {
        long Id { get; set; }
        long SiteId { get; set; }
        DateTime TimeStamp { get; set; }
        string Description { get; set; }
        string Solution { get; set; }
        bool ErrorIndicatior { get; set; }
    }
}
