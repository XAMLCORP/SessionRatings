using Gaming.Foundation.Interfaces;
using Gaming.Ratings.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Gaming.Ratings.Repositories
{
    public class Module : IModule
    {
        public void RegisterTypes(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IRatingRepository, RatingRepository>();
        }
    }
}
