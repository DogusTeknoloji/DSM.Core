using DSM.Core.Interfaces.Management;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSM.Core.Models.Management
{
    public class Client : IClient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOnline { get; set; }
        public DateTime LastOnlineDate { get; set; }
        public DateTime AgentInstallDate { get; set; }
        public DateTime LastDataReceived { get; set; }
    }
}
