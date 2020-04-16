using Gaming.Foundation.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Gaming.Sessions.Repositories
{
    public class Module : IModule
    {
        public void RegisterTypes(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ISessionRepository, SessionRepository>();
            serviceCollection.AddTransient<ISessionUserRepository, SessionUserRepository>();
        }
    }
}
