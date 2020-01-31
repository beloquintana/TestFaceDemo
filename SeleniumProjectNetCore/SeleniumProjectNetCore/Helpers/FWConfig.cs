using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SeleniumProjectNetCore.Helpers
{
    public class FWConfig
    {
        private const string ConfigFileName = "appsettings.json";
        private static IConfigurationBuilder Builder;

        private static readonly Lazy<FWConfig> lazy = new Lazy<FWConfig>(() => new FWConfig());

        public static FWConfig Instance { get { return lazy.Value; } }

        private FWConfig()
        {
            Builder = new ConfigurationBuilder();
            Builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), ConfigFileName));
        }
        public string GetValue(string key)
        {
            return Builder.Build().GetSection(key).Value.ToString();
        }
    }
}
