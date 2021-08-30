using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanArchitecture.DataAccess.Areas.DbContexts.Contexts;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Models;

namespace Mmu.CleanArchitecture.DataAccess.Areas.Repositories.Base.Implementation
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase
        where TEntity : EntityBase
    {
        private DbSet<TEntity> _dbSet;

        public async Task DeleteAsync(long id)
        {
            var loadedEntity = await LoadAsync(qry => qry.SingleOrDefaultAsync(f => f.Id.Equals(id)));

            if (loadedEntity == null)
            {
                return;
            }

            _dbSet.Remove(loadedEntity);
        }

        protected async Task<TResult> LoadAsync<TResult>(Func<IQueryable<TEntity>, Task<TResult>> queryBuilder)
        {
            var qry = await queryBuilder(_dbSet);

            return qry;
        }

        public async Task UpsertAsync(TEntity entity)
        {
            if (entity.Id.Equals(default))
            {
                await _dbSet.AddAsync(entity);
            }
            else
            {
                _dbSet.Update(entity);
            }
        }

        public async Task UpsertRangeAsync(IReadOnlyCollection<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                await UpsertAsync(entity);
            }
        }

        void IRepositoryBase.Initialize(IAppDbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }
    }
}