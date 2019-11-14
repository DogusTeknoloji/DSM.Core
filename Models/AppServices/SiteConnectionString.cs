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
        [StringLimit(512)] private string rawConnectionString;
        [StringLimit(200)] private string serverName;
        [StringLimit(200)] private string databaseName;
        [StringLimit(200)] private string userName;
        [StringLimit(200)] private string password;
        [StringLimit(256)] private string connectionName;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public long SiteId { get; set; }
        public string RawConnectionString { get => rawConnectionString; set => rawConnectionString = value.Limit(512); }
        public string ServerName { get => serverName; set => serverName = value.Limit(200); }
        public int Port { get; set; }
        public string DatabaseName { get => databaseName; set => databaseName = value.Limit(200); }
        public string UserName { get => userName; set => userName = value.Limit(200); }
        public string Password { get => password; set => password = value.Limit(200); }
        public bool IsAvailable { get; set; }
        public long ResponseTime { get; set; }
        public DateTime LastCheckTime { get; set; } = new DateTime(1900, 01, 01);
        public DateTime DeleteDate { get; set; } = new DateTime(1900, 01, 01);
        public bool SendAlertMailWhenUnavailable { get; set; } = true;
        [ExcludeFromDataModel]
        [JsonIgnore]
        public ISite Site { get; set; }
        public string ConnectionName { get => connectionName; set => connectionName = value.Limit(256); }

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
