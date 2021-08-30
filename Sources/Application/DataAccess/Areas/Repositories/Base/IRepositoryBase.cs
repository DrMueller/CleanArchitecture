using Mmu.CleanArchitecture.DataAccess.Areas.DbContexts.Contexts;

namespace Mmu.CleanArchitecture.DataAccess.Areas.Repositories.Base
{
    internal interface IRepositoryBase
    {
        internal void Initialize(IAppDbContext dbContext);
    }
}