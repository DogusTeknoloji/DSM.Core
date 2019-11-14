using DSM.Core.Interfaces.LogServices;
using DSM.Core.PackageManager;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSM.Core.Models.LogServices
{
    [Serializable]
    public class SiteLog : ISiteLog
    {
        [StringLimit(200)] private string serverSiteName;
        [StringLimit(200)] private string serverComputerName;
        [StringLimit(72)] private string serverIp;
        [StringLimit(50)] private string serverPort;
        [StringLimit(50)] private string clientIp;
        [StringLimit(200)] private string clientBrowserVersion;
        [StringLimit(200)] private string clientUserName;
        [StringLimit(200)] private string clientUserAgent;
        [StringLimit(50)] private string clientRequestedMethod;
        [StringLimit(500)] private string clientRequestedUri;
        [StringLimit(500)] private string clientRequestedUriQuery;
        [StringLimit(200)] private string clientRequestedCookie;
        [StringLimit(100)] private string clientRequestedReferer;
        [StringLimit(200)] private string clientRequestedHost;
        [StringLimit(50)] private string serverResponseCode;
        [StringLimit(50)] private string serverResponseSubStatus;
        [StringLimit(50)] private string serverWin32Code;
        [StringLimit(50)] private string serverReceivedBytes;
        [StringLimit(50)] private string serverSentBytes;
        [StringLimit(50)] private string serverResponseTimeMiliseconds;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long SiteId { get; set; }
        public DateTime LogDate { get; set; }
        public string ServerSiteName { get => serverSiteName; set => serverSiteName = value.Limit(200); }
        public string ServerComputerName { get => serverComputerName; set => serverComputerName = value.Limit(200); }
        public string ServerIp { get => serverIp; set => serverIp = value.Limit(72); }
        public string ServerPort { get => serverPort; set => serverPort = value.Limit(50); }
        public string ClientIp { get => clientIp; set => clientIp = value.Limit(50); }
        public string ClientBrowserVersion { get => clientBrowserVersion; set => clientBrowserVersion = value.Limit(200); }
        public string ClientUserName { get => clientUserName; set => clientUserName = value.Limit(200); }
        public string ClientUserAgent { get => clientUserAgent; set => clientUserAgent = value.Limit(200); }
        public string ClientRequestedMethod { get => clientRequestedMethod; set => clientRequestedMethod = value.Limit(50); }
        public string ClientRequestedUri { get => clientRequestedUri; set => clientRequestedUri = value.Limit(500); }
        public string ClientRequestedUriQuery { get => clientRequestedUriQuery; set => clientRequestedUriQuery = value.Limit(500); }
        public string ClientRequestedCookie { get => clientRequestedCookie; set => clientRequestedCookie = value.Limit(200); }
        public string ClientRequestedReferer { get => clientRequestedReferer; set => clientRequestedReferer = value.Limit(100); }
        public string ClientRequestedHost { get => clientRequestedHost; set => clientRequestedHost = value.Limit(200); }
        public string ServerResponseCode { get => serverResponseCode; set => serverResponseCode = value.Limit(50); }
        public string ServerResponseSubStatus { get => serverResponseSubStatus; set => serverResponseSubStatus = value.Limit(50); }
        public string ServerWin32Code { get => serverWin32Code; set => serverWin32Code = value.Limit(50); }
        public string ServerReceivedBytes { get => serverReceivedBytes; set => serverReceivedBytes = value.Limit(50); }
        public string ServerSentBytes { get => serverSentBytes; set => serverSentBytes = value.Limit(50); }
        public string ServerResponseTimeMiliseconds { get => serverResponseTimeMiliseconds; set => serverResponseTimeMiliseconds = value.Limit(50); }
    }
}
