using System;

namespace DSM.Core.Interfaces.AppServices
{
    public interface ISiteTransaction
    {
        DateTime LogDate { get; set; }
        string RequestBrowserVersion { get; set; }
        string RequestCookie { get; set; }
        string RequestedIp { get; set; }
        string RequestHost { get; set; }
        string RequestMethod { get; set; }
        string RequestReferer { get; set; }
        int RequestTimeTakenMiliSeconds { get; set; }
        int RequestTransferedBytes { get; set; }
        string RequestUri { get; set; }
        string RequestUriQuery { get; set; }
        string RequestUserAgent { get; set; }
        string RequestUsername { get; set; }
        string ServerComputerName { get; set; }
        string ServerIp { get; set; }
        int ServerPort { get; set; }
        string ServerSiteName { get; set; }
        int ServiceStatus { get; set; }
        int ServiceSubStatus { get; set; }
        int ServiceTransferedBytes { get; set; }
        int ServiceWin32Status { get; set; }
        long SiteId { get; set; }
    }
}
