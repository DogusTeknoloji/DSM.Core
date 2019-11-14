using DSM.Core.Interfaces.Management;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSM.Core.Models.Management
{
    public class ServiceParameter : IServiceParameter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; }
        public bool IsObsolete { get; set; }
        public short ServiceId { get; set; }
        public short ClientId { get; set; }
    }
}
