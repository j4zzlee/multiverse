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
        /// <param name="app">The application.</param>
        public static void UseModulars(this IApplicationBuilder app)
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var allModules = Directory.GetFiles(assemblyPath, "bc.modules.*.dll")
                .Select(f => Assembly.Load(new AssemblyName(Path.GetFileNameWithoutExtension(f))))
                .SelectMany(a => a.DefinedTypes)
                .Where(t => typeof(IModule).GetTypeInfo().IsAssignableFrom(t.AsType())
                            && !t.IsAbstract
                            && !t.IsInterface)
                .Select(t => (IModule)Activator.CreateInstance(t.AsType()));

            foreach (var m in allModules)
            {
                m
                    .SetApplication(app)
                    .Load();
            }
        }

        /// <summary>
        /// Uses the modulars.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void UseModulars(this IServiceCollection services)
        {
            var mvcBuilder = services.AddMvc();
            services.AddSingleton(o => mvcBuilder);
            services.AddSingleton(o => services);
        }
    }
}
