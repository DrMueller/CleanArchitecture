using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Specifications;

namespace Ardalis.Specification
{
    public abstract class Specification<T, TResult> : Specification<T>, ISpecification<T, TResult>
    {
        protected new virtual ISpecificationBuilder<T, TResult> Query { get; }

        protected Specification()
        {
            this.Query = new SpecificationBuilder<T, TResult>(this);
        }

        public Expression<Func<T, TResult>>? Selector { get; internal set; }

        public new Func<IEnumerable<TResult>, IEnumerable<TResult>>? PostProcessingAction { get; internal set; } = null;
    }

    public abstract class Specification<T> : ISpecification<T>
    {
        protected virtual ISpecificationBuilder<T> Query { get; }

        protected Specification()
        {
            this.Query = new SpecificationBuilder<T>(this);
        }

        public IEnumerable<Expression<Func<T, bool>>> WhereExpressions { get; } = new List<Expression<Func<T, bool>>>();

        public IEnumerable<(Expression<Func<T, object>> KeySelector, OrderType OrderType)> OrderExpressions { get; } = 
            new List<(Expression<Func<T, object>> KeySelector, OrderType OrderType)>();

        public IEnumerable<IncludeExpressionInfo> IncludeExpressions { get; } = new List<IncludeExpressionInfo>();

        public IEnumerable<string> IncludeStrings { get; } = new List<string>();

        public IEnumerable<(Expression<Func<T, string>> Selector, string SearchTerm, int SearchGroup)> SearchCriterias { get; } =
            new List<(Expression<Func<T, string>> Selector, string SearchTerm, int SearchGroup)>();

        public int? Take { get; internal set; }

        public int? Skip { get; internal set; }
        public bool IsPagingEnabled { get; internal set; }
        public Func<IEnumerable<T>, IEnumerable<T>>? PostProcessingAction { get; internal set; }
        public string? CacheKey { get; internal set; }
        public bool CacheEnabled { get; internal set; }
        public bool AsNoTracking { get; internal set; }
        public bool AsSplitQuery { get; internal set; }
        public bool AsNoTrackingWithIdentityResolution { get; internal set; };
    }
}