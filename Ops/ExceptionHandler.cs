using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DSM.Core.Ops
{
    public static class ExceptionHandler
    {
        private static LogManager logManager = LogManager.GetManager("ExceptionHandler");
        private static ConsoleTheming.ConsoleColorSetRed colorSet = ConsoleTheming.ConsoleColorSetRed.Instance;
        private static void WriteGenericLog(Exception ex)
        {
            logManager.Write(ex.Message);
            logManager.Write(ex.StackTrace);
            logManager.Write(ex.HResult.ToString());
            logManager.Write(ex.Source);
            logManager.Write(ex.Data.ToString());
        }
        public static void WebException(WebException ex)
        {
            WriteGenericLog(ex);
            logManager.Write(ex.Response.ResponseUri.AbsoluteUri);
            XConsole.WriteLine(ex.ToString(), colorSet);
            XConsole.WriteLine(ex.Response.ResponseUri.AbsoluteUri, colorSet);
        }

        public static void JsonException(JsonException ex)
        {
            WriteGenericLog(ex);
            XConsole.WriteLine(ex.ToString(), colorSet);
        }

        public static void Exception(Exception ex)
        {
            WriteGenericLog(ex);
            XConsole.WriteLine(ex.ToString(), colorSet);
        }
    }
}