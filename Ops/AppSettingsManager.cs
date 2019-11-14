
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace DSM.Core.Ops
{
    public class AppSettingsManager
    {
        private static Dictionary<string, IConfiguration> settings = new Dictionary<string, IConfiguration>();

        public static IConfiguration GetConfiguration(string filename = "appsettings.json")
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                return null;
            }

            if (settings[filename] == null)
            {
                settings[filename] = new ConfigurationBuilder()
                     .AddJsonFile(filename)
                     .Build();
            }

            return settings[filename];
        }
    }
}