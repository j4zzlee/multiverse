using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace bc.cores.modular
{
    public abstract class BaseModule: IModule
    {
        protected IServiceCollection ServiceCollection;
        protected IMvcBuilder MvcBuilder;
        protected IServiceProvider ServiceProvider;
        
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

        public IModule SetServiceCollection(IServiceCollection serviceCollection)
        {
            ServiceCollection = serviceCollection;
            return this;
        }

        public IModule SetMvcBuilder(IMvcBuilder mvcBuilder)
        {
            MvcBuilder = mvcBuilder;
            return this;
        }

        public IModule SetServiceProvider(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
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
            ServiceCollection.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Add(fileProvider);
            });
            return this;
        }

        protected abstract IModule RegisterServices();
    }
}
