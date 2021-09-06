using JetBrains.Annotations;
using Lamar;
using Mmu.CleanArchitecture.DataAccess.Areas.DbContexts.Contexts.Implementation;
using Mmu.CleanArchitecture.DataAccess.Areas.DbContexts.Factories;
using Mmu.CleanArchitecture.DataAccess.Areas.DbContexts.Factories.Implementation;
using Mmu.CleanArchitecture.DataAccess.Areas.Querying.Services.Implementation;
using Mmu.CleanArchitecture.DataAccess.Areas.Repositories.Generic.Implementation;
using Mmu.CleanArchitecture.DataAccess.Areas.UnitOfWorks.Implementation;
using Mmu.CleanArchitecture.DataAccess.Areas.UnitOfWorks.Servants;
using Mmu.CleanArchitecture.DataAccess.Areas.UnitOfWorks.Servants.Implementation;
using Mmu.CleanArchitecture.DomainServices.Areas.Common.Querying.Services;
using Mmu.CleanArchitecture.DomainServices.Areas.Common.Repositories;
using Mmu.CleanArchitecture.DomainServices.Areas.Common.UnitOfWorks;

namespace Mmu.CleanArchitecture.DataAccess.Infrastructure.DependencyInjection
{
    [UsedImplicitly]
    public class RegistryCollection : ServiceRegistry
    {
        public RegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<RegistryCollection>();
                    scanner.AddAllTypesOf<IRepository>();
                    scanner.Exclude(type => type == typeof(AppDbContext));
                    scanner.WithDefaultConventions();
                });

            For(typeof(IRepository<>)).Use(typeof(GenericRepository<>)).Transient();
            For<IRepositoryCache>().Use<RepositoryCache>().Transient();

            For<IAppDbContextFactory>().Use<AppDbContextFactory>().Singleton();
            For<IUnitOfWorkFactory>().Use<UnitOfWorkFactory>().Singleton();
            For<IQueryService>().Use<QueryService>().Singleton();
            For<IUnitOfWork>().Use<UnitOfWork>().Transient();
        }
    }
}