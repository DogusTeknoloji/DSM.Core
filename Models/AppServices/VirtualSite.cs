using DSM.Core.Interfaces.AppServices;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSM.Core.Models
{
    [Obsolete("Merged with Site model", error: false)]
    public class VirtualSite : IVirtualSite
    {
        // Mark as primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Generate Identity automatically (Auto Identity(1,1)) :)
        [Key]
        public int Id { get; set; }
        public long SiteId { get; set; }
        public string Name { get; set; }
        public string ApplicationPoolName { get; set; }
        public string EnabledProtocols { get; set; }
        public string PhysicalPath { get; set; }
    }
}
