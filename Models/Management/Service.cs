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
            public static short MonitorService => 1;
            public static short EndpointTracker => 2;
            public static short CSTTracker => 3;
            public static short NancyGateway => 4;
            public static short PostOffice => 5;
            public static short WebConfBackup => 6;
            public static short SiteTransactions => 7;
        }
    }
}
