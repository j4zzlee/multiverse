using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace bc.cores.modulars
{
    public abstract class BaseModule: IModule
    {
        protected IServiceCollection Services;
        protected IServiceProvider ServiceProvider;
        protected IApplicationBuilder ApplicationBuilder;
        protected IMvcBuilder MvcBuilder;

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

        public IModule AddMvc(IMvcBuilder mvcBuilder)
        {
            MvcBuilder = mvcBuilder;
            return this;
        }

        public virtual IModule Load()
        {
            UseMvc();
            return this;
        }

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
//            ApplicationBuilder.UseStaticFiles(new StaticFileOptions
//            {
//                FileProvider = fileProvider,
//            });
            return this;
        }
    }
}
