using DSM.Core.Interfaces.AppServices;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSM.Core.Models
{
    public class SiteTransaction : ISiteTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public long SiteId { get; set; }
        private DateTime _logDate = DateTime.Now;
        public DateTime LogDate
        {
            get
            {
                string dt = string.Concat(RLDate, " ", RLTime);
                DateTime.TryParse(dt, out DateTime result);
                if (result == default(DateTime))
                {
                    result = DateTime.Now;
                }

                _logDate = result;
                return _logDate;
            }
            set => _logDate = value;
        }
        public string RLDate { get; set; }
        public string RLTime { get; set; }
        public string ServerSiteName { get; set; }
        public string ServerComputerName { get; set; }
        public string ServerIp { get; set; }
        public string RequestMethod { get; set; }
        public string RequestUri { get; set; }
        public string RequestUriQuery { get; set; }
        public int ServerPort { get; set; }
        public string RequestUsername { get; set; }
        public string RequestedIp { get; set; }
        public string RequestBrowserVersion { get; set; }
        public string RequestUserAgent { get; set; }
        public string RequestCookie { get; set; }
        public string RequestReferer { get; set; }
        public string RequestHost { get; set; }
        public int ServiceStatus { get; set; }
        public int ServiceSubStatus { get; set; }
        public int ServiceWin32Status { get; set; }
        public int ServiceTransferedBytes { get; set; }
        public int RequestTransferedBytes { get; set; }
        public int RequestTimeTakenMiliSeconds { get; set; }
    }
}
