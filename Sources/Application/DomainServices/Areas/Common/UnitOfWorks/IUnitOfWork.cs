using System;
using System.Threading.Tasks;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Models;
using Mmu.CleanArchitecture.DomainServices.Areas.Common.Repositories;

namespace Mmu.CleanArchitecture.DomainServices.Areas.Common.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetGenericRepository<TEntity>()
            where TEntity : EntityBase;

        TRepo GetRepository<TRepo>()
            where TRepo : IRepository;

        Task SaveAsync();
    }
}