using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lamar;

namespace Mmu.CleanArchitecture.WebApi.Infrastructure.DependencyInjection
{
    public class RegistryCollection : ServiceRegistry
    {
        public RegistryCollection()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<RegistryCollection>();
                scanner.WithDefaultConventions();
            });
        }
    }
}
