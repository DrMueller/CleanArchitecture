using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanArchitecture.DataAccess.Areas.DbContexts.Factories;
using Mmu.CleanArchitecture.DataAccess.Areas.Querying.Services.Servants;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Models;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Specifications;
using Mmu.CleanArchitecture.DomainServices.Areas.Common.DataAccess.Querying.Services;

namespace Mmu.CleanArchitecture.DataAccess.Areas.Querying.Services.Implementation
{
    public class QueryService : IQueryService
    {
        private readonly IAppDbContextFactory _appDbContextFactory;
        private readonly ISpecificationEvaluator _specEvaluator;

        protected QueryService(
            IAppDbContextFactory appDbContextFactory,
            ISpecificationEvaluator specEvaluator)
        {
            _appDbContextFactory = appDbContextFactory;
            _specEvaluator = specEvaluator;
        }

        public async Task<IReadOnlyCollection<TResult>> QueryAsync<TEntity, TResult>(ISelectSpecification<TEntity, TResult> spec) where TEntity : EntityBase
        {
            using var appDbContext = _appDbContextFactory.Create();
            var dbSet = appDbContext.Set<TEntity>().AsNoTracking();

            var query = _specEvaluator.ApplySpecification(dbSet, spec);

            var selectSet = query.Select(spec.Selector);
            var result = await selectSet.ToListAsync();

            return result;
        }

        public async Task<IReadOnlyCollection<TEntity>> QueryAsync<TEntity>(ISpecification<TEntity> spec) where TEntity : EntityBase
        {
            using var appDbContext = _appDbContextFactory.Create();
            var dbSet = appDbContext.Set<TEntity>().AsNoTracking();

            var query =  _specEvaluator.ApplySpecification(dbSet, spec);
            
            var result = await query.ToListAsync();
            return result;
        }
    }
}