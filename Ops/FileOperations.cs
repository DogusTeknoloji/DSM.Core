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
            }
            return svcTimer;
        }

        public static string GetSystemDrive
        {
            get
            {
                string systemDirectory = Environment.SystemDirectory;
                return Path.GetPathRoot(systemDirectory);
            }
        }
    }
}
