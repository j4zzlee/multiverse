using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace bc.cores.modular
{
    public interface IModule
    {
        IModule SetApplication(IApplicationBuilder app);
        IModule Load();
    }
}
