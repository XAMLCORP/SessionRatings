using Microsoft.Extensions.Configuration;

namespace Gaming.Sessions.Repositories
{
    internal static class ConfigurationExtensions
    {
        public static string GetSessionsDatabaseConnection(this IConfiguration configuration)
        {
            return configuration.GetSection(DatabaseConnection.SessionsDatabaseConnection).Value;
        }
    }
}
