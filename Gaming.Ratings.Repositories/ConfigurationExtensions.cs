using Gaming.Ratings.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gaming.Ratings.Repositories
{
    internal static class ConfigurationExtensions
    {
        public static string GetSessionsDatabaseConnection(this IConfiguration configuration)
        {
            return configuration.GetSection(DatabaseConnection.RatingsDatabaseConnection).Value;
        }
    }
}
