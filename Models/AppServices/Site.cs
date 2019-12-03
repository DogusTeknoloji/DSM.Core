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
        [StringLimit(100)] private string _machineName;
        [StringLimit(250)] private string _name;
        [StringLimit(100)] private string _applicationPoolName;
        [StringLimit(512)] private string _physicalPath;
        [StringLimit(100)] private string _enabledProtocols;
        [StringLimit(256)] private string _logFileDirectory;
        [StringLimit(50)] private string _logFormat;
        [StringLimit(50)] private string _logPeriod;
        [StringLimit(72)] private string _state;
        [StringLimit(512)] private string _traceFailedRequestsLoggingDirectory;
        [StringLimit(200)] private string _webConfigBackupDirectory;
        [StringLimit(30)] private string _appType = "Root";
        [StringLimit(50)] private string _netFrameworkVersion;


        // Mark as primary key
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Generate Identity automatically (Auto Identity(1,1)) :)
        [Column("Id", Order = 1)]
        public long SiteId { get; set; }                                                                                                //-> 8 byte

        [Column("IISSiteId", Order = 2)]
        public long? IISSiteId { get; set; }                                                                                         //-> 8 byte

        [Column("MachineName", Order = 3)]
        public string MachineName { get => _machineName; set => _machineName = value.Limit(100); }                                               //-> 100 byte + 4 byte address

        [Column("Name", Order = 4)]
        public string Name { get => _name; set => _name = value.Limit(250); }                                                                    //-> 100 byte + 4 byte address

        [Column("ApplicationPoolName", Order = 5)]
        public string ApplicationPoolName { get => _applicationPoolName; set => _applicationPoolName = value.Limit(100); }                       //-> 100 byte + 4 byte address

        [Column("PhysicalPath", Order = 6)]
        public string PhysicalPath { get => _physicalPath; set => _physicalPath = value.Limit(512); }                                            //-> 150 byte + 4 byte address

        [Column("EnabledProtocols", Order = 7)]
        public string EnabledProtocols { get => _enabledProtocols; set => _enabledProtocols = value.Limit(100); }                                //-> 50 byte  + 4 byte address

        [Column("MaxBandwitdh", Order = 8)]
        public long MaxBandwitdh { get; set; }                                                                                      //-> 8 byte

        [Column("MaxConnections", Order = 9)]
        public long MaxConnections { get; set; }                                                                                    //-> 8 byte

        [Column("LogFileEnabled", Order = 10)]
        public bool LogFileEnabled { get; set; }                                                                                    //-> 1 byte

        [Column("LogFileDirectory", Order = 11)]
        public string LogFileDirectory { get => _logFileDirectory; set => _logFileDirectory = value.Limit(256); }                                //-> 150 byte + 4 byte address

        [Column("LogFormat", Order = 12)]
        public string LogFormat { get => _logFormat; set => _logFormat = value.Limit(50); }                                                     //-> 20 byte  + 4 byte address

        [Column("LogPeriod", Order = 13)]
        public string LogPeriod { get => _logPeriod; set => _logPeriod = value.Limit(50); }                                                                                       //-> 30 byte  + 4 byte address

        [Column("ServerAutoStart", Order = 14)]
        public bool ServerAutoStart { get; set; }                                                                                   //-> 1 byte

        [Column("State", Order = 15)]
        public string State { get => _state; set => _state = value.Limit(72); }                                                                //-> 30 byte  + 4 byte address

        [Column("TraceFailedRequestsLoggingEnabled", Order = 16)]
        public bool TraceFailedRequestsLoggingEnabled { get; set; }                                                                 //-> 1 byte

        [Column("TraceFailedRequestsLoggingDirectory", Order = 17)]
        public string TraceFailedRequestsLoggingDirectory { get => _traceFailedRequestsLoggingDirectory; set => _traceFailedRequestsLoggingDirectory = value.Limit(512); } //-> 150 byte  + 4 byte address

        [Column("LastUpdated", Order = 18]
        public DateTime LastUpdated { get; set; } = new DateTime(1900, 01, 01);

        [Column("DateDeleted", Order = 19)]
        public DateTime DateDeleted { get; set; } = new DateTime(1900, 01, 01);

        [Column("WebConfigBackupDirectory", Order = 20)]
        public string WebConfigBackupDirectory { get => _webConfigBackupDirectory; set => _webConfigBackupDirectory = value.Limit(200); }        //-> 150 byte  + 4 byte address

        [Column("WebConfigLastBackupDate", Order = 21)]
        public DateTime WebConfigLastBackupDate { get; set; } = new DateTime(1900, 01, 01);

        [Column("AppType", Order = 22)]
        public string AppType { get => _appType; set => _appType = value.Limit(30); }

        [Column("IsAvailable", Order = 23)]
        public bool IsAvailable { get; set; } = true;                                                                               //-> 1 byte

        [Column("LastCheckTime", Order = 24)]
        public DateTime LastCheckTime { get; set; } = new DateTime(1900, 01, 01);

        [Column("SendAlertMailWhenUnavailable", Order = 25)]
        public bool SendAlertMailWhenUnavailable { get; set; } = true;                                                              //-> 1 byte

        [Column("NetFrameworkVersion", Order = 26)]
        public string NetFrameworkVersion { get => _netFrameworkVersion; set => _netFrameworkVersion = value.Limit(50); }                       //-> 70 byte

        //-> Summary: 1190 byte => 1,162 KB       

        [JsonIgnore, ExcludeFromDataModel]
        public object RawBindings { get; set; }

        [JsonIgnore, ExcludeFromDataModel]
        public virtual SiteWebConfiguration Configuration { get; set; }
        [JsonIgnore, ExcludeFromDataModel]
        public virtual ICollection<SiteBinding> Bindings { get; set; }
        [JsonIgnore, ExcludeFromDataModel]
        public virtual ICollection<SiteConnectionString> ConnectionStrings { get; set; }
        [JsonIgnore, ExcludeFromDataModel]
        public virtual ICollection<SiteEndpoint> Endpoints { get; set; }
        [JsonIgnore, ExcludeFromDataModel]
        public virtual ICollection<SitePackage> Packages { get; set; }

        public object Clone()
        {
            return new Site
            {
                ApplicationPoolName = ApplicationPoolName,
                AppType = AppType,
                DateDeleted = DateDeleted,
                EnabledProtocols = EnabledProtocols,
                SiteId = SiteId,
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
            return WebTransfer.GetConfiguration(SiteId);
        }

        public IEnumerable<SiteConnectionString> GetDBConnectionStrings()
        {
            return WebTransfer.GetSiteConnectionStrings(SiteId);
        }

        public IEnumerable<SiteEndpoint> GetDBEndpoints()
        {
            return WebTransfer.GetSiteEndpoints(SiteId);
        }


    }
}
