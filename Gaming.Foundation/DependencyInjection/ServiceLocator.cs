using Microsoft.Extensions.DependencyInjection;

namespace Gaming.Foundation.DependencyInjection
{
    public static class ServiceLocator
    {
        public static ServiceProvider Instance { get; set; }
    }
}
