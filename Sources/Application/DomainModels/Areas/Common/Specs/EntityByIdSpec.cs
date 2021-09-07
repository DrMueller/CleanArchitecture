using System.Linq;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Models;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Specifications;

namespace Mmu.CleanArchitecture.DomainModels.Areas.Common.Specs
{
    public class EntityByIdSpec<TEntity> : ISpecification<TEntity>
        where TEntity : EntityBase
    {
        private readonly long _entityId;

        public EntityByIdSpec(long entityId)
        {
            _entityId = entityId;
        }

        public IQueryable<TEntity> Apply(IQueryable<TEntity> qry)
        {
            return qry.Where(f => f.Id == _entityId);
        }
    }
}