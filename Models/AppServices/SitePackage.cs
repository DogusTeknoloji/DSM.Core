using DSM.Core.Interfaces.AppServices;
using DSM.Core.PackageManager;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSM.Core.Models
{
    public class SitePackage : ISitePackage
    {
        [StringLimit(100)] private string name;
        [StringLimit(50)] private string newVersion;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public long SiteId { get; set; }
        public string Name { get => name; set => name = value.Limit(100); }
        public string NewVersion { get => newVersion; set => newVersion = value.Limit(50); }
    }
}
