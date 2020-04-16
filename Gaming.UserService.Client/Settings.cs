using Gaming.Foundation.Configuration;
using System;

namespace Gaming.UserService
{
    public static class Settings
    {
        private static string _serviceUrl = String.Empty;
        public static string UserServiceUrl
        {
            get
            {
                if (_serviceUrl == String.Empty)
                    _serviceUrl = Configuration.Instance.GetSection("Services:UserService").Value;
                return _serviceUrl;
            }
        }
    }
}
