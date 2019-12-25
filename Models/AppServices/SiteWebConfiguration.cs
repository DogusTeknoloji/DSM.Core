using DSM.Core.Interfaces.AppServices;
using DSM.Core.PackageManager;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSM.Core.Models
{
    public class SiteWebConfiguration : ISiteWebConfiguration
    {
        [StringLimit(64000)] private string _contentRaw;
        [Column("Id", Order = 1)]
        public long SiteId { get; set; }

        [Column("ContentRaw", Order = 2)]
        public string ContentRaw { get => _contentRaw; set => _contentRaw = value?.Limit(64000); }

        public virtual Site Site { get; set; }
    }
}