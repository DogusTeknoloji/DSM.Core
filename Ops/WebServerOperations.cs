using System;
using System.IO;

namespace DSM.Core.Ops
{
    public static class WebServerOperations
    {
        private static readonly LogManager manager = LogManager.GetManager("DSM.Core.Ops.WebServerOperations");
        public static bool IsIISServerInstalled()
        {
            //\system32\inetsrv\InetMgr.exe
            string iisPath = string.Join("\\", Environment.SystemDirectory, "inetsrv", "InetMgr.exe");
            iisPath.AutoPathRepair();
            if (!File.Exists(iisPath))
            {
                manager.Write(iisPath + " path is empty.");
                manager.Write("IIS is not installed on this server!");
                return false;
            }

            return true;
        }
    }
}