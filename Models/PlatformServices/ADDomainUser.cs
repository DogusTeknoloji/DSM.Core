using DSM.Core.Interfaces.PlatformServices;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSM.Core.Models.PlaftormServices
{
    public class ADDomainUser : IADDomainUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string OfficeName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public string SamAccountName { get; set; }
        public bool InternetAccessEnabled { get; set; }
        public string HomeServer { get; set; }
        public string UserAddress { get; set; }
        public string Manager { get; set; }
        public string DOITGroup { get; set; }
        public string Department { get; set; }
        public string Company { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string KYMAktif { get; set; }
        public string KYMCompany { get; set; }
        public string KYMDateOfBirth { get; set; }
        public string KYMDateOfHire { get; set; }
        public string KYMDepartment { get; set; }
        public string KYMDisplayName { get; set; }
        public string KYMDoId { get; set; }
        public string KYMManager { get; set; }
        public string KYMMobilePhone { get; set; }
        public string KYMTitle { get; set; }
        public string Domain { get; set; }
    }
}
