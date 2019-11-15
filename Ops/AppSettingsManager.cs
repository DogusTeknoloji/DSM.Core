
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

namespace DSM.Core.Ops
{
    public class AppSettingsManager
    {
        private static Dictionary<string, IConfiguration> settings = new Dictionary<string, IConfiguration>();

        public static IConfiguration GetConfiguration(string filename = "appsettings.json")
        {
            if (string.IsNullOrWhiteSpace(filename) || !File.Exists(filename))
            {
                return null;
            }

            if (!settings.ContainsKey(filename))
            {
                settings.Add(filename, new ConfigurationBuilder()
                     .AddJsonFile(filename)
                     .Build());
            }

            return settings[filename];
        }
    }
}