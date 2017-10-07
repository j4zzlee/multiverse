using System;
using bc.cores.modular;

namespace bc.modulars.repositories
{
    public class ModuleDefinition: BaseModule
    {
        protected override IModule RegisterServices()
        {
            return this;
        }
    }
}
