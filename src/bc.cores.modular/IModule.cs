using System;
using Microsoft.Extensions.DependencyInjection;

namespace bc.cores.modular
{
    public interface IModule
    {
        IModule Load();
        IModule SetServiceCollection(IServiceCollection serviceCollection);
        IModule SetMvcBuilder(IMvcBuilder mvcBuilder);
        IModule SetServiceProvider(IServiceProvider serviceProvider);
    }
}
