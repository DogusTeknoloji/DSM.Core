using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSM.Core.Models
{
    public class IISAlertMailRecipient
    {
        [Key]  //Mark as primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Generate Identity automatically (Auto Identity(1,1)) :)
        public int Id { get; set; }
        public string MailAddress { get; set; }
        public string DisplayName { get; set; }
        [Required]
        public bool IsDirectRecipient { get; set; } = true;
        [Required]
        public bool IsCCRecipient { get; set; } = false;
        [Required]
        public bool IsBCCRecipient { get; set; } = false;
    }
}
