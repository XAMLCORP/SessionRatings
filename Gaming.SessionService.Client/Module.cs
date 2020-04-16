using Gaming.Client.Interfaces.Services;
using Gaming.Foundation.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Gaming.SessionService
{
    public class Module : IModule
    {
        public void RegisterTypes(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ISessionService, SessionService>();
        }
    }
}
