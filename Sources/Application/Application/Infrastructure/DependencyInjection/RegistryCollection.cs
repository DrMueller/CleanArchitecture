using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lamar;
using Mmu.CleanArchitecture.Application.Areas.Settings.Services;

namespace Mmu.CleanArchitecture.Application.Infrastructure.DependencyInjection
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
