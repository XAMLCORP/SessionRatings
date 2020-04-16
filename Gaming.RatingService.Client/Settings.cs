using Gaming.Foundation.Configuration;
using System;

namespace Gaming.RatingService
{
    public static class Settings
    {
        private static string _serviceUrl = String.Empty;
        public static string RatingServiceUrl 
        {
            get
            {
                if (_serviceUrl == String.Empty)
                    _serviceUrl = Configuration.Instance.GetSection("Services:RatingService").Value;
                return _serviceUrl;
            }
        }
    }
}
