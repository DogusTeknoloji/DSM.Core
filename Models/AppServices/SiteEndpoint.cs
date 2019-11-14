using DSM.Core.Interfaces.AppServices;
using DSM.Core.PackageManager;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSM.Core.Models
{
    public class SiteEndpoint : ICloneable, ISiteEndpoint
    {
        [StringLimit(150)] private string destinationServer;
        [StringLimit(150)] private string destinationAddress;
        [StringLimit(100)] private string destinationAddressType;
        [StringLimit(250)] private string hostInformation;
        [StringLimit(200)] private string endpointUrl;
        [StringLimit(300)] private string serverResponseDescription;
        [StringLimit(100)] private string httpProtocol;
        [StringLimit(256)] private string endpointName;

        [Key]  //Mark as primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DestinationServer { get => destinationServer; set => destinationServer = value.Limit(150); }
        public string DestinationAddress { get => destinationAddress; set => destinationAddress = value.Limit(150); }
        public string DestinationAddressType { get => destinationAddressType; set => destinationAddressType = value.Limit(100); }
        public string HostInformation { get => hostInformation; set => hostInformation = value.Limit(250); }
        public int Port { get; set; }
        public string EndpointUrl { get => endpointUrl; set => endpointUrl = value.Limit(200); }
        public bool IsAvailable { get; set; }
        public int ServerResponse { get; set; }
        public string ServerResponseDescription { get => serverResponseDescription; set => serverResponseDescription = value.Limit(300); }
        public string HttpProtocol { get => httpProtocol; set => httpProtocol = value.Limit(100); }
        public DateTime LastCheckDate { get; set; } = new DateTime(1900, 01, 01);
        public DateTime DeleteDate { get; set; } = new DateTime(1900, 01, 01);
        public bool DeleteStatus { get; set; } = false;
        public bool SendAlertMailWhenUnavailable { get; set; } = true;
        public long SiteId { get; set; }
        public long ResponseTime { get; set; }
        public string EndpointName { get => endpointName; set => endpointName = value.Limit(256); }
        [ExcludeFromDataModel]
        [JsonIgnore]
        public Site Site { get; set; } = new Site();

        public object Clone()
        {
            return new SiteEndpoint
            {
                Id = Id,
                DeleteDate = DeleteDate,
                DestinationAddress = DestinationAddress,
                DestinationAddressType = DestinationAddressType,
                DestinationServer = DestinationServer,
                EndpointUrl = EndpointUrl,
                HostInformation = HostInformation,
                HttpProtocol = HttpProtocol,
                IsAvailable = IsAvailable,
                LastCheckDate = LastCheckDate,
                Port = Port,
                SendAlertMailWhenUnavailable = SendAlertMailWhenUnavailable,
                ServerResponse = ServerResponse,
                ServerResponseDescription = ServerResponseDescription,
                SiteId = SiteId,
                EndpointName = EndpointName
            };
        }
    }
}
