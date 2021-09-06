using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanArchitecture.DataAccess.Areas.DbContexts.Factories;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Models;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Specifications;
using Mmu.CleanArchitecture.DomainServices.Areas.Common.Querying.Services;

namespace Mmu.CleanArchitecture.DataAccess.Areas.Querying.Services.Implementation
{
    public class QueryService : IQueryService
    {
        private readonly IAppDbContextFactory _appDbContextFactory;

        public QueryService(IAppDbContextFactory appDbContextFactory)
        {
            _appDbContextFactory = appDbContextFactory;
        }

        public async Task<IReadOnlyCollection<TResult>> QueryAsync<TEntity, TResult>(ISpecification<TEntity, TResult> spec) where TEntity : EntityBase
        {
            using var appDbContext = _appDbContextFactory.Create();
            var dbSet = appDbContext.Set<TEntity>().AsNoTracking();

            var query = spec.Apply(dbSet);

            var selectSet = query.Select(spec.Selector);
            var result = await selectSet.ToListAsync();

            return result;
        }

        public async Task<IReadOnlyCollection<TEntity>> QueryAsync<TEntity>(ISpecification<TEntity> spec) where TEntity : EntityBase
        {
            using var appDbContext = _appDbContextFactory.Create();
            var dbSet = appDbContext.Set<TEntity>().AsNoTracking();
            var query = spec.Apply(dbSet);

            var result = await query.ToListAsync();

            return result;
        }
    }
}