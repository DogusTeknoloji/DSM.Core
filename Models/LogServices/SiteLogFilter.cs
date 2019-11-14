using DSM.Core.Interfaces.LogServices;
using DSM.Core.PackageManager;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSM.Core.Models.LogServices
{
    public class SiteLogFilter : ISiteLogFilter
    {
        [StringLimit(5)] private string name;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get => name; set => name = value.Limit(5); }
    }
}
