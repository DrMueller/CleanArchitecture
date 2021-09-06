using System;
using System.Linq;
using System.Linq.Expressions;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Models;

namespace Mmu.CleanArchitecture.DomainModels.Areas.Base.Specifications
{
    public interface ISpecification<TEntity, TResult> : ISpecification<TEntity>
        where TEntity : EntityBase
    {
        Expression<Func<TEntity, TResult>> Selector { get; }
    }

    public interface ISpecification<TEntity>
        where TEntity : EntityBase
    {
        IQueryable<TEntity> Apply(IQueryable<TEntity> qry);
    }
}