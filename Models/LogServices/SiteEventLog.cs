using DSM.Core.Interfaces.LogServices;
using DSM.Core.PackageManager;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSM.Core.Models.LogServices
{
    public class SiteEventLog : ISiteEventLog
    {
        [StringLimit(256)] private string description;
        [StringLimit(256)] private string solution;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long SiteId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Description { get => description; set => description = value?.Limit(256); }
        public string Solution { get => solution; set => solution = value?.Limit(256); }
        public bool ErrorIndicatior { get; set; }
    }
}
