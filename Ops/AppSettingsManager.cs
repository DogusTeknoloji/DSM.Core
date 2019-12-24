
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

namespace DSM.Core.Ops
{
    public static class AppSettingsManager
    {
        private static readonly Dictionary<string, IConfiguration> _settings = new Dictionary<string, IConfiguration>();

        public static IConfiguration GetConfiguration()
        {
            IConfiguration result = GetConfiguration("appsettings.json");
            return result;
        }

        public static IConfiguration GetConfiguration(string filename)
        {
            string result = Path.Combine(FileOperations.AssemblyDirectory, filename);
            if (string.IsNullOrWhiteSpace(filename) || !File.Exists(result))
            {
                return null;
            }

            if (!_settings.ContainsKey(filename))
            {
                _settings.Add(filename, new ConfigurationBuilder()
                     .AddJsonFile(filename)
                     .Build());
            }

            return _settings[filename];
        }
    }
}