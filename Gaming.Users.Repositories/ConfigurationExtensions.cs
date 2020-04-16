using Gaming.Users.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gaming.Users.Repositories
{
    internal static class ConfigurationExtensions
    {
        public static string GetUsersDatabaseConnection(this IConfiguration configuration)
        {
            return configuration.GetSection(DatabaseConnection.UsersDatabaseConnection).Value;
        }
    }
}
