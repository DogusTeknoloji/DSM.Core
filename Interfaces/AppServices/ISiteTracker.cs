using System;

namespace DSM.Core.Interfaces.AppServices
{
    public interface ISiteTracker
    {
        bool IsAvailable { get; set; }
        DateTime LastCheckTime { get; set; }
        bool SendAlertMailWhenUnavailable { get; set; }
    }
}
