using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Common
{
    public class ConfigurationHelper
    {
        private static string EnvironmentName { get; set; } = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? string.Empty;

        /// <summary>The configuration root</summary>
        public static IConfigurationRoot Configuration { get; set; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile($"appsettings.{EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables()
            //.AddCommandLine(args)
            .Build();

        /// <summary>Logging settings</summary>
        //public static LoggingSettings LoggingConfiguration => ConfigurationHelper.Get<LoggingSettings>("LoggingSettings");

        //public static BrowserSettings BrowserConfiguration => ConfigurationHelper.Get<BrowserSettings>("BrowserSettings");

        /// <summary>Web application URL</summary>
        //public static string ApplicationLoaction => ConfigurationHelper.GetValueAsString("AppLocation") ?? "http://localhost:3000";

        /// <summary>Returns a configuration value as a string</summary>
        /// <param name="key">The key of the configuration</param>
        /// <returns></returns>
        public static string GetValueAsString(string key) => ConfigurationHelper.Configuration[key];

        /// <summary>Returns a configuration value as an integer</summary>
        /// <param name="key">The key of the configuration</param>
        /// <param name="defaultVal">The default value to return in case no key found</param>
        /// <returns></returns>
        public static int GetValueAsInteger(string key, int? defaultVal = null)
        {
            string s = ConfigurationHelper.Configuration[key];
            int result;
            if (s != null && int.TryParse(s, out result))
                return result;
            return defaultVal.HasValue ? defaultVal.Value : throw new InvalidCastException("Value is not an integer");
        }

        /// <summary>Returns a configuration value as boolean</summary>
        /// <param name="key">The key of the configuration</param>
        /// <param name="defaultVal">The default value to return in case no key found</param>
        /// <returns></returns>
        public static bool GetValueAsBool(string key, bool? defaultVal = null)
        {
            string str = ConfigurationHelper.Configuration[key];
            bool result;
            if (str != null && bool.TryParse(str, out result))
                return result;
            return defaultVal.HasValue ? defaultVal.Value : throw new InvalidCastException("Value is not an integer");
        }

        /// <summary>Retrieves the specified section if exists</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(string key) where T : new()
        {
            T obj = new T();
            IConfigurationSection section = ConfigurationHelper.Configuration.GetSection(key);
            if (section != null)
                section.Bind((object)obj);
            return obj;
        }
    }
}
