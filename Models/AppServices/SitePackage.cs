using DSM.Core.Interfaces.AppServices;
using DSM.Core.PackageManager;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSM.Core.Models
{
    public class SitePackage : ISitePackage
    {
        [StringLimit(100)] private string _name;
        [StringLimit(50)] private string _version;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 1)]
        public int Id { get; set; }

        [Column("SiteId", Order = 2)]
        public long SiteId { get; set; }

        public virtual Site Site { get; set; }

        [Column("Name", Order = 3)]
        public string Name { get => _name; set => _name = value.Limit(100); }

        [Column("NewVersion", Order = 4)]
        public string Version { get => _version; set => _version = value.Limit(50); }
    }
}
