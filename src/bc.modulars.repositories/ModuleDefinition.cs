using System.Linq;
using bc.cores.modular;
using bc.cores.repositories;
using bc.cores.repositories.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace bc.modulars.repositories
{
    public class ModuleDefinition: BaseModule
    {
        protected override IModule RegisterServices()
        {
            var repoInterfaceType = typeof(IRepository<>);
            var repoTypes = repoInterfaceType
                .Assembly
                .DefinedTypes
                .Where(t => 
                    !t.IsInterface
                    && !t.IsAbstract
                    && (
                        t.ImplementedInterfaces.Contains(repoInterfaceType)
                        || t.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == repoInterfaceType)
                    ));
            foreach (var repoTypeInfo in repoTypes)
            {
                var repoType = repoTypeInfo.AsType();
                ServiceCollection.AddScoped(repoType, repoType);
            }
            return this;
        }
    }
}
