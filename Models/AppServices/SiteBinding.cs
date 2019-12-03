using DSM.Core.Interfaces.AppServices;
using DSM.Core.PackageManager;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DSM.Core.Models
{
    public class SiteBinding : ISiteBinding // Table Architecture
    {
        [StringLimit(150)] private string _host;
        [StringLimit(64)] private string _ipAddress;
        [StringLimit(50)] private string _ipAddressFamily;
        [StringLimit(10)] private string _port;
        [StringLimit(40)] private string _protocol;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Generate Identity automatically (Auto Identity(1,1)) :)
        [Column("Id", Order = 1)]
        public int Id { get; set; }

        [Column("Host", Order = 2)]
        public string Host { get => _host; set => _host = value.Limit(150); }

        [Column("SiteId", Order = 3)]
        public long SiteId { get; set; }

        [JsonIgnore, ExcludeFromDataModel]
        public virtual Site Site { get; set; }

        [Column("IsSSLBound", Order = 4)]
        public bool IsSSLBound { get; set; } = false; // SQL side default : false

        [Column("IpAddress", Order = 5)]
        public string IpAddress { get => _ipAddress; set => _ipAddress = value.Limit(64); }

        [Column("IpAddressFamiliy", Order = 6)]
        public string IpAddressFamily { get => _ipAddressFamily; set => _ipAddressFamily = value.Limit(15); }

        [Column("Port", Order = 7)]
        public string Port { get => _port; set => _port = value.Limit(10); }

        [Column("Protocol", Order = 8)]
        public string Protocol { get => _protocol; set => _protocol = value.Limit(40); }

    }
}
