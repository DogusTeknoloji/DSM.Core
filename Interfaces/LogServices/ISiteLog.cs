using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSM.Core.Interfaces.LogServices
{
    public interface ISiteLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        long Id { get; set; }
        long SiteId { get; set; }
        DateTime LogDate { get; set; }

        string ServerSiteName { get; set; }
        string ServerComputerName { get; set; }
        string ServerIp { get; set; }
        string ServerPort { get; set; }

        string ClientIp { get; set; }
        string ClientBrowserVersion { get; set; }
        string ClientUserName { get; set; }
        string ClientUserAgent { get; set; }

        string ClientRequestedMethod { get; set; }
        string ClientRequestedUri { get; set; }
        string ClientRequestedUriQuery { get; set; }

        string ClientRequestedCookie { get; set; }
        string ClientRequestedReferer { get; set; }
        string ClientRequestedHost { get; set; }


        string ServerResponseCode { get; set; }
        string ServerResponseSubStatus { get; set; }
        string ServerWin32Code { get; set; }

        string ServerReceivedBytes { get; set; }
        string ServerSentBytes { get; set; }

        string ServerResponseTimeMiliseconds { get; set; }
    }
}
