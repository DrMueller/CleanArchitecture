using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Models;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Specifications;

namespace Mmu.CleanArchitecture.DomainServices.Areas.Common.Querying.Services
{
    public interface IQueryService
    {
        Task<IReadOnlyCollection<TResult>> QueryAsync<TEntity, TResult>(ISpecification<TEntity, TResult> spec)
            where TEntity : EntityBase;

        Task<IReadOnlyCollection<TEntity>> QueryAsync<TEntity>(ISpecification<TEntity> spec)
            where TEntity : EntityBase;
    }
}