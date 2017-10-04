using System;
using System.IO;
using System.Reflection;
using bc.cores.modulars;
using Microsoft.Extensions.DependencyInjection;

namespace bc.modules.account
{
    public sealed class Module : BaseModule
    {
        public override IModule Load()
        {
            var assemblyPath = new Uri(GetType().GetTypeInfo().Assembly.CodeBase).LocalPath;

//            var assembly = GetType().GetTypeInfo().Assembly;
//            var embbededFileProvider = new EmbeddedFileProvider(assembly, "account_module");

            // Add controllers
            Services
                .AddMvc()
                .AddApplicationPart(Assembly.Load(new AssemblyName(Path.GetFileNameWithoutExtension(assemblyPath))));

//            Services.Configure<RazorViewEngineOptions>(o =>
//            {
//                o.FileProviders.Add(embbededFileProvider);
//            });
            return this;
        }
    }
}
