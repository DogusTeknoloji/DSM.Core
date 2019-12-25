using DSM.Core.Interfaces.AppServices;
using DSM.Core.PackageManager;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSM.Core.Models
{
    public class SiteConnectionString : ICloneable, ISiteConnectionString
    {
        [StringLimit(512)] private string _rawConnectionString;
        [StringLimit(200)] private string _serverName;
        [StringLimit(200)] private string _databaseName;
        [StringLimit(200)] private string _userName;
        [StringLimit(200)] private string _password;
        [StringLimit(256)] private string _connectionName;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 1)]
        public int Id { get; set; }

        [Column("SiteId", Order = 2)]
        public long SiteId { get; set; }

        [Column("RawConnectionString", Order = 3)]
        public string RawConnectionString { get => _rawConnectionString; set => _rawConnectionString = value?.Limit(512); }

        [Column("ServerName", Order = 4)]
        public string ServerName { get => _serverName; set => _serverName = value?.Limit(200); }

        [Column("Port", Order = 5)]
        public int Port { get; set; }

        [Column("DatabaseName", Order = 6)]
        public string DatabaseName { get => _databaseName; set => _databaseName = value?.Limit(200); }

        [Column("UserName", Order = 7)]
        public string UserName { get => _userName; set => _userName = value?.Limit(200); }

        [Column("Password", Order = 8)]
        public string Password { get => _password; set => _password = value?.Limit(200); }

        [Column("IsAvailable", Order = 9)]
        public bool IsAvailable { get; set; }

        [Column("ResponseTime", Order = 10)]
        public long ResponseTime { get; set; }

        [Column("LastCheckTime", Order = 11)]
        public DateTime LastCheckTime { get; set; } = new DateTime(1900, 01, 01);

        [Column("DeleteDate", Order = 12)]
        public DateTime DeleteDate { get; set; } = new DateTime(1900, 01, 01);

        [Column("SendAlertMailWhenUnavailable", Order = 13)]
        public bool SendAlertMailWhenUnavailable { get; set; } = true;

        [JsonIgnore, ExcludeFromDataModel]
        public virtual Site Site { get; set; }

        [Column("ConnectionName", Order = 14)]
        public string ConnectionName { get => _connectionName; set => _connectionName = value?.Limit(256); }

        public object Clone()
        {
            return new SiteConnectionString
            {
                Id = Id,
                DatabaseName = DatabaseName,
                DeleteDate = DeleteDate,
                IsAvailable = IsAvailable,
                LastCheckTime = LastCheckTime,
                Password = Password,
                Port = Port,
                RawConnectionString = RawConnectionString,
                SendAlertMailWhenUnavailable = SendAlertMailWhenUnavailable,
                ServerName = ServerName,
                SiteId = SiteId,
                UserName = UserName,
                ConnectionName = ConnectionName
            };
        }
    }
}
