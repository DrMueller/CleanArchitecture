using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanArchitecture.DataAccess.Areas.DbContexts.Contexts;
using Mmu.CleanArchitecture.DataAccess.Areas.Repositories;
using Mmu.CleanArchitecture.DataAccess.Areas.UnitOfWorks.Servants;
using Mmu.CleanArchitecture.DomainModels.Areas.Base;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Models;
using Mmu.CleanArchitecture.DomainServices.Areas.Common.DataAccess.Repositories;
using Mmu.CleanArchitecture.DomainServices.Areas.Common.DataAccess.UnitOfWorks;

namespace Mmu.CleanArchitecture.DataAccess.Areas.UnitOfWorks.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepositoryCache _repoCache;
        private IAppDbContext _dbContext;

        protected UnitOfWork(IRepositoryCache repoCache)
        {
            _repoCache = repoCache;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public void Initialize(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TRepo GetRepository<TRepo>() where TRepo : IRepository
        {

            var repoType = typeof(IRepository);
            return _repoCache.GetRepository<TRepo>(repoType, _dbContext);
        }

        public async Task SaveAsync()
        {
            SetTechnicalFields();
            await _dbContext.SaveChangesAsync();
        }

        private void SetTechnicalFields()
        {
            var entries = _dbContext.ChangeTrackerr
                .Entries()
                .Where(
                    e => e.State is EntityState.Added or EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                ((EntityBase)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((EntityBase)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }
        }
    }
}