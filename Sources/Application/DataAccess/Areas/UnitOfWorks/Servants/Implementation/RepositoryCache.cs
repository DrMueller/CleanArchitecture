using System;
using System.Collections.Concurrent;
using System.Linq;
using JetBrains.Annotations;
using Lamar;
using Mmu.CleanArchitecture.Common.Areas.FunctionResults;
using Mmu.CleanArchitecture.DataAccess.Areas.DbContexts.Contexts;
using Mmu.CleanArchitecture.DataAccess.Areas.Repositories;
using Mmu.CleanArchitecture.DataAccess.Areas.Repositories.Base;
using Mmu.CleanArchitecture.DomainServices.Areas.Common.DataAccess.Repositories;

namespace Mmu.CleanArchitecture.DataAccess.Areas.UnitOfWorks.Servants.Implementation
{
    [UsedImplicitly]
    internal class RepositoryCache : IRepositoryCache
    {
        private readonly IContainer _container;
        private readonly ConcurrentDictionary<Type, IRepository> _repos;

        public RepositoryCache(IContainer container)
        {
            _container = container;
            _repos = new ConcurrentDictionary<Type, IRepository>();
        }

        public TRepo GetRepository<TRepo>(Type repositoryType, IAppDbContext dbContext)
            where TRepo : IRepository
        {
            var getRepoResult = TryGettingRepository<TRepo>(repositoryType);

            if (getRepoResult.IsSuccess)
            {
                return getRepoResult.Value;
            }

            return InitializeRepository<TRepo>(dbContext);
        }

        private TRepo InitializeRepository<TRepo>(IAppDbContext dbContext)
            where TRepo : IRepository
        {
            var repository = _container.GetInstance<TRepo>();

            if (!(repository is IRepositoryBase repoBase))
            {
                throw new ArgumentException($"{nameof(TRepo)} does not implement RepositoryBase");
            }

            repoBase.Initialize(dbContext);
            _repos.AddOrUpdate(repository.GetType(), repository, (type, repo) => repo);

            return repository;
        }

        private FunctionResult<TRepo> TryGettingRepository<TRepo>(Type repositoryType)
            where TRepo : IRepository
        {
            var cachedRepo = _repos.SingleOrDefault(f => repositoryType.IsAssignableFrom(f.Key));
            var castedRepo = (TRepo)cachedRepo.Value;

            return FunctionResult.CreateFromDefault(castedRepo);
        }
    }
}