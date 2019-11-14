using DSM.Core.Interfaces.AppServices;
using DSM.Core.PackageManager;

namespace DSM.Core.Models
{
    public class SiteWebConfiguration : ISiteWebConfiguration
    {
        [StringLimit(64000)] private string contentRaw;

        public long Id { get; set; }
        public string ContentRaw { get => contentRaw; set => contentRaw = value.Limit(64000); }
    }
}
