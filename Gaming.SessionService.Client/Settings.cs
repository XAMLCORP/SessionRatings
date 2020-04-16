using Gaming.Foundation.Configuration;
using System;

namespace Gaming.SessionService
{
    public static class Settings
    {
        private static string _serviceUrl = String.Empty;
        public static string SessionServiceUrl
        {
            get
            {
                if (_serviceUrl == String.Empty)
                    _serviceUrl = Configuration.Instance.GetSection("Services:SessionService").Value;
                return _serviceUrl;
            }
        }
    }
}
