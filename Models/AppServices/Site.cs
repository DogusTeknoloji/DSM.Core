using DSM.Core.Interfaces.AppServices;
using DSM.Core.Ops;
using DSM.Core.PackageManager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSM.Core.Models
{
    public partial class Site : ISite // Table Architecture
    {
        [StringLimit(100)] private string machineName;
        [StringLimit(250)] private string name;
        [StringLimit(100)] private string applicationPoolName;
        [StringLimit(512)] private string physicalPath;
        [StringLimit(100)] private string enabledProtocols;
        [StringLimit(256)] private string logFileDirectory;
        [StringLimit(50)] private string logFormat;
        [StringLimit(50)] private string logPeriod;
        [StringLimit(72)] private string state;
        [StringLimit(512)] private string traceFailedRequestsLoggingDirectory;
        [StringLimit(200)] private string webConfigBackupDirectory;
        [StringLimit(30)] private string appType = "Root";
        [StringLimit(50)] private string netFrameworkVersion;

        private DateTime lastCheckTime = new DateTime(1900, 01, 01);
        private DateTime webConfigLastBackupDate = new DateTime(1900, 01, 01);
        private DateTime dateDeleted = new DateTime(1900, 01, 01);
        private DateTime lastUpdated = new DateTime(1900, 01, 01);


        // Mark as primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Generate Identity automatically (Auto Identity(1,1)) :)
        [Key]
        public long Id { get; set; }                                                                                                //-> 8 byte
        public long IISSiteId { get; set; }                                                                                         //-> 8 byte
        public string MachineName { get => machineName; set => machineName = value.Limit(100); }                                               //-> 100 byte + 4 byte address
        public string Name { get => name; set => name = value.Limit(250); }                                                                    //-> 100 byte + 4 byte address
        public string ApplicationPoolName { get => applicationPoolName; set => applicationPoolName = value.Limit(100); }                       //-> 100 byte + 4 byte address
        public string PhysicalPath { get => physicalPath; set => physicalPath = value.Limit(512); }                                            //-> 150 byte + 4 byte address
        public string EnabledProtocols { get => enabledProtocols; set => enabledProtocols = value.Limit(100); }                                //-> 50 byte  + 4 byte address
        public long MaxBandwitdh { get; set; }                                                                                      //-> 8 byte
        public long MaxConnections { get; set; }                                                                                    //-> 8 byte
        public bool LogFileEnabled { get; set; }                                                                                    //-> 1 byte
        public string LogFileDirectory { get => logFileDirectory; set => logFileDirectory = value.Limit(256); }                                //-> 150 byte + 4 byte address
        public string LogFormat { get => logFormat; set => logFormat = value.Limit(50); }                                                     //-> 20 byte  + 4 byte address
        public string LogPeriod { get => logPeriod; set => logPeriod = value.Limit(50); }                                                                                       //-> 30 byte  + 4 byte address
        public bool ServerAutoStart { get; set; }                                                                                   //-> 1 byte
        public string State { get => state; set => state = value.Limit(72); }                                                                //-> 30 byte  + 4 byte address
        public bool TraceFailedRequestsLoggingEnabled { get; set; }                                                                 //-> 1 byte
        public string TraceFailedRequestsLoggingDirectory { get => traceFailedRequestsLoggingDirectory; set => traceFailedRequestsLoggingDirectory = value.Limit(512); } //-> 150 byte  + 4 byte address
        public DateTime LastUpdated { get => lastUpdated; set => lastUpdated = value; }
        public DateTime DateDeleted { get => dateDeleted; set => dateDeleted = value; }
        public string WebConfigBackupDirectory { get => webConfigBackupDirectory; set => webConfigBackupDirectory = value.Limit(200); }        //-> 150 byte  + 4 byte address
        public DateTime WebConfigLastBackupDate { get => webConfigLastBackupDate; set => webConfigLastBackupDate = value; }
        public string AppType { get => appType; set => appType = value.Limit(30); }
        public bool IsAvailable { get; set; } = true;                                                                               //-> 1 byte
        public DateTime LastCheckTime { get => lastCheckTime; set => lastCheckTime = value; }
        public bool SendAlertMailWhenUnavailable { get; set; } = true;                                                              //-> 1 byte
        public string NetFrameworkVersion { get => netFrameworkVersion; set => netFrameworkVersion = value.Limit(50); }                       //-> 70 byte

        //-> Summary: 1190 byte => 1,162 KB       

        [ExcludeFromDataModel]
        [JsonIgnore]
        public object RawBindings { get; set; }

        public object Clone()
        {
            return new Site
            {
                ApplicationPoolName = ApplicationPoolName,
                AppType = AppType,
                DateDeleted = DateDeleted,
                EnabledProtocols = EnabledProtocols,
                Id = Id,
                IISSiteId = IISSiteId,
                IsAvailable = IsAvailable,
                LastCheckTime = LastCheckTime,
                LastUpdated = LastUpdated,
                LogFileDirectory = LogFileDirectory,
                LogFileEnabled = LogFileEnabled,
                LogFormat = LogFormat,
                LogPeriod = LogPeriod,
                MachineName = MachineName,
                MaxBandwitdh = MaxBandwitdh,
                MaxConnections = MaxConnections,
                Name = Name,
                NetFrameworkVersion = NetFrameworkVersion,
                PhysicalPath = PhysicalPath,
                RawBindings = RawBindings,
                SendAlertMailWhenUnavailable = SendAlertMailWhenUnavailable,
                ServerAutoStart = ServerAutoStart,
                State = State,
                TraceFailedRequestsLoggingDirectory = TraceFailedRequestsLoggingDirectory,
                TraceFailedRequestsLoggingEnabled = TraceFailedRequestsLoggingEnabled,
                WebConfigBackupDirectory = WebConfigBackupDirectory,
                WebConfigLastBackupDate = WebConfigLastBackupDate
            };
        }

        public SiteWebConfiguration GetConfiguration()
        {
            return WebTransfer.GetConfiguration(Id);
        }


        public IEnumerable<SiteConnectionString> GetDBConnectionStrings()
        {
            return WebTransfer.GetSiteConnectionStrings(Id);
        }

        public IEnumerable<SiteEndpoint> GetDBEndpoints()
        {
            return WebTransfer.GetSiteEndpoints(Id);
        }
    }
}
