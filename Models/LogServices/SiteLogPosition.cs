using DSM.Core.Interfaces.LogServices;
using DSM.Core.PackageManager;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSM.Core.Models.LogServices
{
    public class SiteLogPosition : ISiteLogPosition
    {
        [StringLimit(0)] private string filePath;
        [StringLimit(0)] private string states;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long SiteId { get; set; }
        public string FilePath { get => filePath; set => filePath = value.Limit(0); }
        public long CursorPointer { get; set; }
        public long FileSize { get; set; }
        public long Transfered { get; set; }
        public DateTime LastPackage { get; set; }
        public string States { get => states; set => states = value.Limit(0); }
    }
}
