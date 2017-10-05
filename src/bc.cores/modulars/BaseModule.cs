using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace bc.cores.modulars
{
    public abstract class BaseModule: IModule
    {
        protected IServiceCollection Services;
        protected IServiceProvider ServiceProvider;
        protected IApplicationBuilder ApplicationBuilder;

        /// <summary>
        /// Sets the service conllection.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public virtual IModule SetServiceConllection(IServiceCollection services)
        {
            Services = services;
            return this;
        }

        /// <summary>
        /// Sets the service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns></returns>
        public virtual IModule SetServiceProvider(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            return this;
        }

        /// <summary>
        /// Sets the application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <returns></returns>
        public virtual IModule SetApplication(IApplicationBuilder app)
        {
            ApplicationBuilder = app;
            return this;
        }

        public virtual IModule Load()
        {
            UseMvc();
            return this;
        }

        protected virtual IModule UseMvc()
        {
            var assemblyPath = new Uri(GetType().GetTypeInfo().Assembly.CodeBase).LocalPath;
            Services
                .AddMvc()
                .AddApplicationPart(Assembly.Load(new AssemblyName(Path.GetFileNameWithoutExtension(assemblyPath))));
            return this;
        }
    }
}
