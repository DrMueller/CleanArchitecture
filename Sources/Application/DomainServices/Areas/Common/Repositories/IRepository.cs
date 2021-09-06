using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Models;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Specifications;

namespace Mmu.CleanArchitecture.DomainServices.Areas.Common.Repositories
{
    [SuppressMessage("Design", "CA1040:Avoid empty interfaces", Justification = "Marker interface for easier generic handling")]
    public interface IRepository
    {
    }

    public interface IRepository<TEntity> : IRepository
        where TEntity : EntityBase
    {
        Task DeleteAsync(long id);

        Task<IReadOnlyCollection<TEntity>> LoadAllAsync(ISpecification<TEntity> spec);

        Task<TEntity> LoadAsync(ISpecification<TEntity> spec);

        Task UpsertAsync(TEntity entity);
    }
}