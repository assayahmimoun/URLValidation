using System.Configuration;

namespace URL.Validation.Client.Common.Helper
{
    public static class ConfigurationManagerHelper
    {
        public static string URLValidationAPIHost
        {
            get
            {
                string host = ConfigurationManager.AppSettings["URL.Validation.API.Host"];
                if (string.IsNullOrWhiteSpace(host))
                    host = "http://localhost:8181/";

                return host;
            }
        }
    }
}
