using System;
using System.IO;

namespace DSM.Core.Ops
{
    public class LogManager : IDisposable
    {
        private static LogManager _logManager;
        public static LogManager GetManager(string name)
        {
            if (_logManager == null)
            {
                _logManager = new LogManager(name);
            }
            return _logManager;
        }

        private const string filePath = @"C:\DSMService_LOGS\";
        private const string fileName = "DEBUG.txt";
        private static StreamWriter swriter;

        private LogManager(string name)
        {
            string fullPath = string.Concat(filePath, name, @"\", DateTime.Now.ToString("yyMMdd"), "_", fileName);

            bool isPathRepaired = fullPath.AutoPathRepair();
            if (isPathRepaired)
            {
                swriter = new StreamWriter(fullPath, append: true);
            }
        }
        public void Write(string log)
        {
            string message = $"{DateTime.Now} ";
            string fLog = string.Concat(message, " ", log);
            swriter.WriteLine(fLog);
            swriter.Flush();
        }


        public void Dispose()
        {
            swriter.Dispose();
        }
    }
}
