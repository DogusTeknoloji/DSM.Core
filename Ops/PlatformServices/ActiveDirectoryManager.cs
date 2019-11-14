using DSM.Core.Models.PlaftormServices;
using DSM.Core.Ops.ConsoleTheming;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace DSM.Core.Ops.PlatformServices
{
    public class ActiveDirectoryManager
    {

        public static List<ADDomainUser> GetDomainUsers(string apiKey)
        {
            XConsole.SetDefaultColorSet(ConsoleColorSetRed.Instance);
            List<ADDomainUser> domainUsers = new List<ADDomainUser>();
            foreach (ADDomain domain in GetDomains(apiKey))
            {
                XConsole.WriteLine($"Context Switching;{domain.DomainName}", ConsoleColorSetGreen.Instance);
                try
                {
                    using (PrincipalContext context = new PrincipalContext(ContextType.Domain, domain.DomainName))
                    using (PrincipalSearcher searcher = new PrincipalSearcher(new UserPrincipal(context)))
                    {
                        foreach (Principal principal in searcher.FindAll())
                        {
                            DirectoryEntry entry = (DirectoryEntry)principal.GetUnderlyingObject();

                            bool isUserEnabled = IsUserEnabled((int)entry.Properties["userAccountControl"].Value);
                            if (!isUserEnabled)
                            {
                                continue;
                            }

                            ADDomainUser domainUser = new ADDomainUser
                            {
                                Domain = domain.DomainName,
                                Name = entry.Properties["givenName"].Value.Get<string>(),
                                Company = entry.Properties["company"].Value.Get<string>(),
                                CreatedDate = entry.Properties["whenCreated"].Value.Get<DateTime>(),
                                Department = entry.Properties["department"].Value.Get<string>(),
                                DOITGroup = entry.Properties["doitPrimaryGroup"].Value.Get<string>(),
                                FullName = entry.Properties["name"].Value.Get<string>(),
                                HomeServer = entry.Properties["msRTCSIP-PrimaryHomeServer"].Value.Get<string>(),
                                InternetAccessEnabled = entry.Properties["msRTCSIP-InternetAccessEnabled"].Value.Get<bool>(),
                                LastModifiedDate = entry.Properties["whenChanged"].Value.Get<DateTime>(),
                                Manager = entry.Properties["manager"].Value.Get<string>(),
                                OfficeName = entry.Properties["physicalDeliveryOfficeName"].Value.Get<string>(),
                                SamAccountName = entry.Properties["samAccountName"].Value.Get<string>(),
                                Surname = entry.Properties["sn"].Value.Get<string>(),
                                UserAddress = entry.Properties["msRTCSIP-PrimaryUserAddress"].Value.Get<string>(),
                                KYMAktif = entry.Properties["kYMAktif"].Value.Get<string>(),
                                KYMCompany = entry.Properties["kymCompany"].Value.Get<string>(),
                                KYMDateOfBirth = entry.Properties["kymDateofBirth"].Value.Get<string>(),
                                KYMDateOfHire = entry.Properties["kymDateofHire"].Value.Get<string>(),
                                KYMDepartment = entry.Properties["kymDepartment"].Value.Get<string>(),
                                KYMDisplayName = entry.Properties["kymDisplayName"].Value.Get<string>(),
                                KYMDoId = entry.Properties["kymdoid"].Value.Get<string>(),
                                KYMManager = entry.Properties["kymManager"].Value.Get<string>(),
                                KYMMobilePhone = entry.Properties["kymMobilePhone"].Value.Get<string>(),
                                KYMTitle = entry.Properties["kymTitle"].Value.Get<string>()
                            };
                            domainUsers.Add(domainUser);
                            XConsole.WriteLine($"{domainUser.FullName} ->");
                        }
                    }
                }
                catch (Exception ex)
                {
                    XConsole.WriteLine($"An exception occured context switch failed=> {domain.DomainName}, {ex.Message}", ConsoleColorSetBlueW.Instance);
                    string key = "abort".ToLower();
                    XConsole.WriteLine($"Please type \"{key}\" to quit, or press Enter to continue");
                    //string msg = XConsole.ReadLine();
                    //if (msg.ToLower() == key) Environment.Exit(-1);
                }
            }
            XConsole.WriteLine("Operation Done");
            return domainUsers;
        }

        private static bool IsUserEnabled(int value)
        {
            return value == 512;
        }
        private static IList<ADDomain> GetDomains(string apiKey)
        {
            List<ADDomain> domains = WebOperations.WebGet<List<ADDomain>>(WebOperations.WebMethod.GET_ADDOMAIN_LIST, apiKey);
            return domains;
        }
    }
}
