using Mmu.CleanArchitecture.DataAccess.Areas.Repositories.Base.Implementation;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Models;
using Mmu.CleanArchitecture.DomainServices.Areas.Common.Repositories;

namespace Mmu.CleanArchitecture.DataAccess.Areas.Repositories.Generic.Implementation
{
    public class GenericRepository<TEntity> : RepositoryBase<TEntity>, IRepository<TEntity>
        where TEntity : EntityBase
    {
    }
}