using DSM.Core.Models;
using System;

namespace DSM.Core.Interfaces.AppServices
{
    public interface ISiteEndpoint
    {
        int Id { get; set; }
        long SiteId { get; set; }
        string EndpointUrl { get; set; }
        bool DeleteStatus { get; set; }
        DateTime DeleteDate { get; set; }
        string DestinationAddress { get; set; }
        string DestinationAddressType { get; set; }
        string DestinationServer { get; set; }
        string HostInformation { get; set; }
        string HttpProtocol { get; set; }
        bool IsAvailable { get; set; }
        DateTime LastCheckDate { get; set; }
        int Port { get; set; }
        int ServerResponse { get; set; }
        string ServerResponseDescription { get; set; }
        bool SendAlertMailWhenUnavailable { get; set; }
        long ResponseTime { get; set; }
        Site Site { get; set; }
    }
}
