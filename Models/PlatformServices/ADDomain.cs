using DSM.Core.Interfaces.PlatformServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSM.Core.Models.PlaftormServices
{
    public class ADDomain : IADDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string IpAddress { get; set; }
        public string DomainName { get; set; }
    }
}
