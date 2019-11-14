using DSM.Core.Interfaces.Management;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSM.Core.Models.Management
{
    public class Service : IService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short Id { get; set; }
        public string Name { get; set; }

        public struct Names
        {
            public const short MonitorService = 1;
            public const short EndpointTracker = 2;
            public const short CSTTracker = 3;
            public const short NancyGateway = 4;
            public const short PostOffice = 5;
            public const short WebConfBackup = 6;
            public const short SiteTransactions = 7;
        }
    }
}
