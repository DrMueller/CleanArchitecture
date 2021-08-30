using System;
using Mmu.CleanArchitecture.DataAccess.Areas.DbContexts.Contexts;
using Mmu.CleanArchitecture.DataAccess.Areas.Repositories;
using Mmu.CleanArchitecture.DomainServices.Areas.Common.DataAccess.Repositories;

namespace Mmu.CleanArchitecture.DataAccess.Areas.UnitOfWorks.Servants
{
    public interface IRepositoryCache
    {
        TRepo GetRepository<TRepo>(Type repositoryType, IAppDbContext dbContext)
            where TRepo : IRepository;
    }
}