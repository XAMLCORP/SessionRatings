using Gaming.Foundation.DependencyInjection;
using Gaming.Foundation.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Gaming.Foundation
{
    public static class Bootstrapper
    {
        public static ServiceProvider Bootstrap()
        {
            PrimeAppDomain();
            var serviceCollection = new ServiceCollection();                
            LoadModules(serviceCollection);            
            ServiceLocator.Instance = serviceCollection.BuildServiceProvider();
            //BuildConfiguration();
            
            return ServiceLocator.Instance;
        }

        private static void PrimeAppDomain()
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => !x.IsDynamic).ToList();
            var loadedPaths = loadedAssemblies.Select(a => a.Location).ToArray();

            var referencedPaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "Gaming.*.dll");
            var toLoad = referencedPaths.Where(r => !loadedPaths.Contains(r, StringComparer.InvariantCultureIgnoreCase)).ToList();
            toLoad.ForEach(path => loadedAssemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path))));
        }

        static void LoadModules(IServiceCollection serviceCollection)
        {
            var moduleInterface = typeof(IModule);
            var moduleTypes = AppDomain.CurrentDomain.GetAssemblies().Where(x => !x.IsDynamic && x.FullName.StartsWith("Gaming.")).SelectMany(x => x.GetTypes())
                .Where(x => moduleInterface.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).ToList();

            foreach (var moduleType in moduleTypes)
            {
                var module = (IModule)Activator.CreateInstance(moduleType);
                module.RegisterTypes(serviceCollection);
            }
        }

        static void BuildConfiguration()
        {
            Configuration.Configuration.Instance = ServiceLocator.Instance.GetService<IConfiguration>();
        }
    }
}
