using System;
using System.Threading.Tasks;
using Mmu.CleanArchitecture.DomainServices.Areas.Common.DataAccess.Repositories;

namespace Mmu.CleanArchitecture.DomainServices.Areas.Common.DataAccess.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        TRepo GetRepository<TRepo>()
            where TRepo : IRepository;

        Task SaveAsync();
    }
}