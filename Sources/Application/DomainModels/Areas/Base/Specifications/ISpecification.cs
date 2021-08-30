using System;
using System.Collections.Generic;
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
        public IReadOnlyCollection<IncludeExpressionInfo> Includes { get; }
        public Expression<Func<TEntity, bool>> Criteria { get; }
        public Expression<Func<TEntity, object>> OrderBy { get; }
        public Expression<Func<TEntity, object>> OrderByDescending { get; }
    }
}