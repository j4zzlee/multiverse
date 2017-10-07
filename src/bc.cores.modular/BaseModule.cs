using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace bc.cores.modular
{
    public abstract class BaseModule: IModule
    {
        protected IServiceCollection Services;
        protected IServiceProvider ServiceProvider;
        protected IApplicationBuilder ApplicationBuilder;
        protected IMvcBuilder MvcBuilder;

        /// <summary>
        /// Sets the application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <returns></returns>
        public virtual IModule SetApplication(IApplicationBuilder app)
        {
            ApplicationBuilder = app;
            ServiceProvider = app.ApplicationServices;
            Services = ServiceProvider.GetService<IServiceCollection>();
            MvcBuilder = ServiceProvider.GetService<IMvcBuilder>();
            return this;
        }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        /// <returns></returns>
        public virtual IModule Load()
        {
            UseMvc();
            RegisterServices();
            return this;
        }
        
        /// <summary>
        /// Uses the MVC.
        /// </summary>
        /// <returns></returns>
        protected virtual IModule UseMvc()
        {
            var assembly = GetType().GetTypeInfo().Assembly;
            var assemblyPath = new Uri(assembly.CodeBase).LocalPath;
            MvcBuilder.AddApplicationPart(Assembly.Load(new AssemblyName(Path.GetFileNameWithoutExtension(assemblyPath))));

            var fileProvider = new CompositeFileProvider(new EmbeddedFileProvider(assembly));
            Services.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Add(fileProvider);
            });
            return this;
        }

        protected abstract IModule RegisterServices();
    }
}
