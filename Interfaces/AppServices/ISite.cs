using DSM.Core.Models;
using System;
using System.Collections.Generic;

namespace DSM.Core.Interfaces.AppServices
{
    public interface ISite : ISiteBase, ISiteTracker, ICloneable
    {
        long SiteId { get; set; }
        long? IISSiteId { get; set; }
        string MachineName { get; set; }
        long MaxBandwitdh { get; set; }
        long MaxConnections { get; set; }
        bool LogFileEnabled { get; set; }
        string LogFileDirectory { get; set; }
        string LogFormat { get; set; }
        string LogPeriod { get; set; }
        string AppType { get; set; }
        bool ServerAutoStart { get; set; }
        string State { get; set; }
        bool TraceFailedRequestsLoggingEnabled { get; set; }
        string TraceFailedRequestsLoggingDirectory { get; set; }
        DateTime LastUpdated { get; set; }
        DateTime DateDeleted { get; set; }
        string NetFrameworkVersion { get; set; }
        object RawBindings { get; set; }
        SiteWebConfiguration GetConfiguration();
        IEnumerable<SiteEndpoint> GetDBEndpoints();
        IEnumerable<SiteConnectionString> GetDBConnectionStrings();
    }
}
