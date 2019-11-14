using System;

namespace DSM.Core.Interfaces.PlatformServices
{
    public interface IADDomainUser
    {
        string OfficeName { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string FullName { get; set; }
        string SamAccountName { get; set; }
        bool InternetAccessEnabled { get; set; }
        string HomeServer { get; set; }
        string UserAddress { get; set; }
        string Manager { get; set; }
        string DOITGroup { get; set; }
        string Department { get; set; }
        string Company { get; set; }
        DateTime LastModifiedDate { get; set; }
        DateTime CreatedDate { get; set; }
        string KYMAktif { get; set; }
        string KYMCompany { get; set; }
        string KYMDateOfBirth { get; set; }
        string KYMDateOfHire { get; set; }
        string KYMDepartment { get; set; }
        string KYMDisplayName { get; set; }
        string KYMDoId { get; set; }
        string KYMManager { get; set; }
        string KYMMobilePhone { get; set; }
        string KYMTitle { get; set; }
        string Domain { get; set; }
    }
}
