using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace bc.cores.modulars
{
    public interface IModule
    {
        IModule SetServiceConllection(IServiceCollection services);
        IModule SetServiceProvider(IServiceProvider serviceProvider);
        IModule SetApplication(IApplicationBuilder app);
        IModule AddMvc(IMvcBuilder mvcBuilder);
        IModule Load();
    }
}
