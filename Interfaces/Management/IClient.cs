using System;

namespace DSM.Core.Interfaces.Management
{
    public interface IClient
    {
        string Name { get; set; }
        bool IsOnline { get; set; }
        DateTime LastOnlineDate { get; set; }
        DateTime AgentInstallDate { get; set; }
        DateTime LastDataReceived { get; set; }
    }
}
