using DSM.Core.Interfaces.Management;
using DSM.Core.Models.Management;
using System;
using System.IO;
using System.Reflection;

namespace DSM.Core.Ops
{
    public static class FileOperations
    {
        public static bool AutoPathRepair(this string dirPath)
        {
            try
            {
                string CheckLoc = string.Empty;
                string[] location = dirPath.Split('\\');
                for (int i = 0; i < location.Length - 1; i++)
                {
                    CheckLoc = CheckLoc.Insert(CheckLoc.Length, string.Format("{0}\\", location[i]));
                    if (!Directory.Exists(CheckLoc))
                    {
                        Directory.CreateDirectory(CheckLoc);
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public static string AssemblyDirectory
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                string codeBase = assembly.CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
        public static string AssemblyName => Assembly.GetExecutingAssembly().GetName().ToString();

        internal static IServiceTimer GetLocalScheduler(short serviceId)
        {
            IServiceTimer svcTimer = new ServiceTimer();


            switch (serviceId)
            {
                default:
                    svcTimer.Day = 0;
                    svcTimer.Hour = 0;
                    svcTimer.Minute = 0;
                    svcTimer.Second = 40;
                    break;
                    //case Names.MonitorService:
                    //    svcTimer.Day = Properties.Settings.Default.SCH_DAY;
                    //    svcTimer.Hour = Properties.Settings.Default.SCH_HOUR;
                    //    svcTimer.Minute = Properties.Settings.Default.SCH_MINUTE;
                    //    svcTimer.Second = Properties.Settings.Default.SCH_SECOND;
                    //    break;
                    //case Names.EndpointTracker:
                    //    svcTimer.Day = Properties.Settings.Default.EPTSCH_DAY;
                    //    svcTimer.Hour = Properties.Settings.Default.EPTSCH_HOUR;
                    //    svcTimer.Minute = Properties.Settings.Default.EPTSCH_MINUTE;
                    //    svcTimer.Second = Properties.Settings.Default.EPTSCH_SECOND;
                    //    break;
                    //case Names.CSTTracker:
                    //    svcTimer.Day = Properties.Settings.Default.EPTSCH_DAY;
                    //    svcTimer.Hour = Properties.Settings.Default.EPTSCH_HOUR;
                    //    svcTimer.Minute = Properties.Settings.Default.EPTSCH_MINUTE;
                    //    svcTimer.Second = Properties.Settings.Default.EPTSCH_SECOND;
                    //    break;
                    //case Names.NancyGateway:
                    //    svcTimer.Day = Properties.Settings.Default.NGW_DAY;
                    //    svcTimer.Hour = Properties.Settings.Default.NGW_HOUR;
                    //    svcTimer.Minute = Properties.Settings.Default.NGW_MINUTE;
                    //    svcTimer.Second = Properties.Settings.Default.NGW_SECOND;
                    //    break;
                    //case Names.PostOffice:
                    //    svcTimer.Day = Properties.Settings.Default.MQH_DAY;
                    //    svcTimer.Hour = Properties.Settings.Default.MQH_HOUR;
                    //    svcTimer.Minute = Properties.Settings.Default.MQH_MINUTE;
                    //    svcTimer.Second = Properties.Settings.Default.MQH_SECOND;
                    //    break;
                    //case Names.WebConfBackup:
                    //    svcTimer.Day = Properties.Settings.Default.WCFGBCK_DAY;
                    //    svcTimer.Hour = Properties.Settings.Default.WCFGBCK_HOUR;
                    //    svcTimer.Minute = Properties.Settings.Default.WCFGBCK_MINUTE;
                    //    svcTimer.Second = Properties.Settings.Default.WCFGBCK_SECOND;
                    //    break;
            }
            return svcTimer;
        }

        public static string GetSystemDrive()
        {
            string systemDirectory = Environment.SystemDirectory;
            return Path.GetPathRoot(systemDirectory);
        }
    }
}
