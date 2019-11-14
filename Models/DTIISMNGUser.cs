using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSM.Core.Models
{
    public class DTIISMNGUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string DomainService { get; set; }
        public string Password { get; set; }
        public string AuthKey { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime LastAttempt { get; set; }
        public string FullName { get; set; }
        public int RoleId { get; set; }
    }
}
