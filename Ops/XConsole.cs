using DSM.Core.Ops.ConsoleTheming;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DSM.Core.Ops
{
    public static class XConsole
    {
        private static readonly Dictionary<string, IConsoleColorSet> _defaultSet = new Dictionary<string, IConsoleColorSet>();
        private static ConsoleColor _bg = Console.BackgroundColor;
        private static ConsoleColor _fg = Console.ForegroundColor;

        private static readonly List<string> _allowedThreadClass = new List<string>();
        private static readonly List<string> _allowedThreadMethod = new List<string>();

        private static readonly Dictionary<string, string> _defaultTitle = new Dictionary<string, string>();

        private static string GetCallerClassName(int stPoint = 2)
        {
            StackFrame frame = new StackFrame(stPoint);
            string className = frame.GetMethod().DeclaringType.Name;
            return className;
        }
        private static string GetCallerMethodName(int stPoint = 2)
        {
            StackFrame frame = new StackFrame(stPoint);
            string methodName = frame.GetMethod().Name;
            return methodName;
        }
        private static void Swap(string className, IConsoleColorSet colorSet = null)
        {
            IConsoleColorSet set = ConsoleColorSetDefault.Instance;
            if (_defaultSet.ContainsKey(className))
            {
                set = _defaultSet[className];
            }

            colorSet = colorSet ?? set;
            _bg = Console.BackgroundColor;
            _fg = Console.ForegroundColor;

            Console.BackgroundColor = colorSet.BackgroundColor;
            Console.ForegroundColor = colorSet.ForegroundColor;
        }
        private static void SwapBack()
        {
            Console.BackgroundColor = _bg;
            Console.ForegroundColor = _fg;
        }
        public static void SetDefaultColorSet(IConsoleColorSet colorSet)
        {
            string className = GetCallerClassName();
            if (!_defaultSet.ContainsKey(className))
            {
                _defaultSet.Add(className, colorSet);
            }
        }
        public static void SetTitle(string value)
        {
            string className = GetCallerClassName();
            if (!_defaultTitle.ContainsKey(className))
            {
                _defaultTitle.Add(className, value + " -> ");
            }
        }
        public static void ResetTitle()
        {
            string className = GetCallerClassName();
            _defaultTitle.Remove(className);
        }
        public static void Write(string value, IConsoleColorSet colorSet = null, bool blockPrefix = false)
        {
            string classname = GetCallerClassName();
            string methodname = GetCallerMethodName();
            if (!_allowedThreadClass.Contains(classname) || !_allowedThreadMethod.Contains(methodname))
            {
                return;
            }

            Swap(classname, colorSet);
            string prefix = _defaultTitle.ContainsKey(classname) ? _defaultTitle[classname] : string.Empty;
            Console.Write((!blockPrefix ? prefix : string.Empty) + value);
            SwapBack();
        }

        public static void WriteLine(string consoleText, object p)
        {
            throw new NotImplementedException();
        }

        public static void WriteLine(string value, IConsoleColorSet colorSet = null, bool blockPrefix = false)
        {
            string classname = GetCallerClassName();
            string methodname = GetCallerMethodName();
            if (!_allowedThreadClass.Contains(classname) || !_allowedThreadMethod.Contains(methodname))
            {
                return;
            }

            Swap(classname, colorSet);
            string prefix = _defaultTitle.ContainsKey(classname) ? _defaultTitle[classname] : string.Empty;
            Console.WriteLine((!blockPrefix ? prefix : string.Empty) + value);
            SwapBack();
        }

        public static void Progress(string stepDescription, int progress, int total)
        {
            const int TOTALCHUNKS = 30;

            //draw empty progress bar
            Console.CursorLeft = 0;
            Console.Write("["); //start
            Console.CursorLeft = TOTALCHUNKS + 1;
            Console.Write("]"); //end
            Console.CursorLeft = 1;

            double pctComplete = Convert.ToDouble(progress) / total;
            int numChunksComplete = Convert.ToInt16(TOTALCHUNKS * pctComplete);

            //draw completed chunks
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("".PadRight(numChunksComplete));

            //draw incomplete chunks
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write("".PadRight(TOTALCHUNKS - numChunksComplete));

            //draw totals
            Console.CursorLeft = TOTALCHUNKS + 5;
            Console.BackgroundColor = _bg;

            string output = progress.ToString() + " of " + total.ToString();
            Console.Write(output.PadRight(15) + stepDescription); //pad the output so when changing from 3 to 4 digits we avoid text shifting
        }
        public static string ReadLine()
        {
            return Console.ReadLine();
        }

        public static ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        public static void WriteEvent(string message, EventType type = EventType.Information)
        {
            string logName = GetCallerClassName();
            bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            const string SOURCENAME = "DSM.Services";

            if (isWindows)
            {
                if (!EventLog.SourceExists(SOURCENAME))
                {
                    EventLog.CreateEventSource(SOURCENAME, logName);
                }

                EventLog log = new EventLog(logName);
                log.Source = SOURCENAME;

                EventLogEntryType entryType = (EventLogEntryType)type;
                log.WriteEntry(message, entryType);
            }
        }

        public static void ResetColor()
        {
            string className = GetCallerClassName();
            _defaultSet.Remove(className);
            Console.ResetColor();
        }


        public static void Clear()
        {
            Console.Clear();
        }

        public static void SilentAll(bool activate = true, bool includeMethods = false)
        {
            string className = GetCallerClassName();
            string methodName = GetCallerMethodName();
            if (activate)
            {
                if (includeMethods && !_allowedThreadMethod.Contains(methodName))
                {
                    _allowedThreadMethod.Add(methodName);
                }

                if (!_allowedThreadClass.Contains(className))
                {
                    _allowedThreadClass.Add(className);
                }

                XConsole.WriteLine($"ALL CHANNELS SILENT WITHOUT {className}~{methodName}");
            }
            else
            {
                _allowedThreadClass.Remove(className);
                _allowedThreadMethod.Remove(methodName);
            }
        }
    }

    public enum EventType
    {
        Information = 4,
        Warning = 2,
        Error = 1,
        FailureAudit = 16,
        SucessAudit = 8
    }
}
