using Gaming.Foundation.Interfaces;
using Gaming.Users.Interfaces.Repositores;
using Microsoft.Extensions.DependencyInjection;

namespace Gaming.Users.Repositories
{
    public class Module : IModule
    {
        public void RegisterTypes(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
