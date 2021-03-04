using Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSampleCasbin
{
    public class AuthoritySettings
    {
        public string Host { get; set; }
    }

    public class AppSettingsHelper: ConfigurationHelper
    {
        public static AuthoritySettings Authority => Get<AuthoritySettings>("Authority");
    }
}
