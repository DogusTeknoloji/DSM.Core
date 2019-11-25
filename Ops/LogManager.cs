using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DSM.Core.Ops
{
    public class LogManager : IDisposable
    {
        private static List<LogManager> _instances = new List<LogManager>();
        public static LogManager GetManager(string name)
        {
            if (_instances.Any(x => x.Name == name))
            {
                return _instances.First(x => x.Name == name);
            }

            return new LogManager(name);
        }
        public string Name { get; set; }
        private const string filePath = @"C:\DSMService_LOGS\";
        private const string fileName = "LOG.txt";
        private static StreamWriter swriter;

        private LogManager(string name)
        {
            this.Name = name;
            _instances.Add(this);

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
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                swriter.Dispose();
            }
        }
    }
}
