using DSM.Core.Interfaces.AppServices;
using DSM.Core.PackageManager;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DSM.Core.Models
{
    public class SiteBinding : ISiteBinding // Table Architecture
    {
        [StringLimit(150)] private string host;
        [StringLimit(64)] private string ipAddress;
        [StringLimit(50)] private string ipAddressFamily;
        [StringLimit(10)] private string port;
        [StringLimit(40)] private string protocol;

        [Key]  //Mark as primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Generate Identity automatically (Auto Identity(1,1)) :)
        public int Id { get; set; }
        public string Host { get => host; set => host = value.Limit(150); }
        public long SiteId { get; set; }
        public bool IsSSLBound { get; set; } = false; // SQL side default : false
        public string IpAddress { get => ipAddress; set => ipAddress = value.Limit(64); }
        public string IpAddressFamily { get => ipAddressFamily; set => ipAddressFamily = value.Limit(15); }
        public string Port { get => port; set => port = value.Limit(10); }
        public string Protocol { get => protocol; set => protocol = value.Limit(40); }

    }
}
