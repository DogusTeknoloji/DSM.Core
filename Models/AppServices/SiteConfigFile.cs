using DSM.Core.PackageManager;
using System;

namespace DSM.Core.Models
{
    public class SiteConfigFile
    {
        [StringLimit(0)] private string siteName;
        [StringLimit(0)] private string machineName;
        [StringLimit(0)] private string contentRaw;

        public string SiteName { get => siteName; set => siteName = value.Limit(0); }
        public string MachineName { get => machineName; set => machineName = value.Limit(0); }
        public string ContentRaw { get => contentRaw; set => contentRaw = value.Limit(0); }
        public DateTime FileModifyDate { get; set; }
    }
}
