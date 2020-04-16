using Microsoft.Extensions.DependencyInjection;

namespace Gaming.Foundation.Interfaces
{
    public interface IModule
    {
        void RegisterTypes(IServiceCollection serviceCollection);
    }
}
