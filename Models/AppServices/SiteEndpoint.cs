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
        [StringLimit(150)] private string _destinationServer;
        [StringLimit(150)] private string _destinationAddress;
        [StringLimit(100)] private string _destinationAddressType;
        [StringLimit(250)] private string _hostInformation;
        [StringLimit(200)] private string _endpointUrl;
        [StringLimit(300)] private string _serverResponseDescription;
        [StringLimit(100)] private string _httpProtocol;
        [StringLimit(256)] private string _endpointName;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 1)]
        public int Id { get; set; }
        [Column("DestinationServer", Order = 2)]
        public string DestinationServer { get => _destinationServer; set => _destinationServer = value?.Limit(150); }
        [Column("DestinationAddress", Order = 3)]
        public string DestinationAddress { get => _destinationAddress; set => _destinationAddress = value?.Limit(150); }
        [Column("DestinationAddressType", Order = 4)]
        public string DestinationAddressType { get => _destinationAddressType; set => _destinationAddressType = value?.Limit(100); }
        [Column("HostInformation", Order = 5)]
        public string HostInformation { get => _hostInformation; set => _hostInformation = value?.Limit(250); }
        [Column("Port", Order = 6)]
        public int Port { get; set; }
        [Column("EndpointUrl", Order = 7)]
        public string EndpointUrl { get => _endpointUrl; set => _endpointUrl = value?.Limit(200); }
        [Column("IsAvailable", Order = 8)]
        public bool IsAvailable { get; set; }
        [Column("ServerResponse", Order = 9)]
        public int ServerResponse { get; set; }
        [Column("ServerResponseDescription", Order = 10)]
        public string ServerResponseDescription { get => _serverResponseDescription; set => _serverResponseDescription = value?.Limit(300); }
        [Column("HttpProtocol", Order = 11)]
        public string HttpProtocol { get => _httpProtocol; set => _httpProtocol = value?.Limit(100); }
        [Column("LastCheckDate", Order = 12)]
        public DateTime LastCheckDate { get; set; } = new DateTime(1900, 01, 01);
        [Column("DeleteDate", Order = 13)]
        public DateTime DeleteDate { get; set; } = new DateTime(1900, 01, 01);
        [Column("DeleteStatus", Order = 14)]
        public bool DeleteStatus { get; set; } = false;
        [Column("SendAlertMailWhenUnavailable", Order = 15)]
        public bool SendAlertMailWhenUnavailable { get; set; } = true;
        [Column("SiteId", Order = 16)]
        public long SiteId { get; set; }
        [Column("ResponseTime", Order = 17)]
        public long ResponseTime { get; set; }
        [Column("EndpointName", Order = 18)]
        public string EndpointName { get => _endpointName; set => _endpointName = value?.Limit(256); }

        [JsonIgnore, ExcludeFromDataModel]
        public virtual Site Site { get; set; } = new Site();

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
