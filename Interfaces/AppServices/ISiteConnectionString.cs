using System;

namespace DSM.Core.Interfaces.AppServices
{
    public interface ISiteConnectionString
    {
        int Id { get; set; }
        long SiteId { get; set; }
        string ServerName { get; set; }
        string DatabaseName { get; set; }
        DateTime DeleteDate { get; set; }
        bool IsAvailable { get; set; }
        DateTime LastCheckTime { get; set; }
        string Password { get; set; }
        int Port { get; set; }
        string RawConnectionString { get; set; }
        string UserName { get; set; }
        bool SendAlertMailWhenUnavailable { get; set; }
        long ResponseTime { get; set; }
        ISite Site { get; set; }
    }
}
