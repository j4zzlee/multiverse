using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace bc.cores.modular
{
    public static class ModularInstaller
    {
        /// <summary>
        /// Uses the modulars.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="builder">The builder.</param>
        public static void UseModulars(this IServiceCollection services, IMvcBuilder builder)
        {
            var mvcBuilder = services.AddMvc();
            services.AddSingleton(o => mvcBuilder);
            var assemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var allModules = Directory.GetFiles(assemblyPath, "bc.modulars.*.dll")
                .Select(f => Assembly.Load(new AssemblyName(Path.GetFileNameWithoutExtension(f))))
                .SelectMany(a => a.DefinedTypes)
                .Where(t => typeof(IModule).GetTypeInfo().IsAssignableFrom(t.AsType())
                            && !t.IsAbstract
                            && !t.IsInterface)
                .Select(t => (IModule)Activator.CreateInstance(t.AsType()));

            foreach (var m in allModules)
            {
                m
                    .SetServiceCollection(services)
                    .SetMvcBuilder(builder)
                    .Load();
                services.AddSingleton(p => m);
            }
        }

        public static void UseModulars(this IApplicationBuilder app, IServiceProvider provider)
        {
            var allModules = provider.GetServices<IModule>();
            foreach (var module in allModules)
            {
                module.SetServiceProvider(provider);
            }
        }
    }
}
