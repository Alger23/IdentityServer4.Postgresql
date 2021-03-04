using Common;
using Microsoft.Extensions.Configuration;

namespace WebApiSample
{
    public class AuthoritySettings
    {
        public string Host { get; set; }
    }

    public class AppSettingsHelper : ConfigurationHelper
    {
        public static AuthoritySettings Authority => Get<AuthoritySettings>("Authority");
    }
}
