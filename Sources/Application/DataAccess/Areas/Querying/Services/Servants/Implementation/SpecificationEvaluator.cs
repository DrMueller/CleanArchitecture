using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Models;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Specifications;

namespace Mmu.CleanArchitecture.DataAccess.Areas.Querying.Services.Servants.Implementation
{
    public class SpecificationEvaluator : ISpecificationEvaluator
    {
        private readonly IIncludeFactory _includeFactory;

        public SpecificationEvaluator(IIncludeFactory includeFactory)
        {
            _includeFactory = includeFactory;
        }

        public IQueryable<TEntity> ApplySpecification<TEntity>(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
            where TEntity: EntityBase
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            foreach (var include in spec.Includes)
            {
                query = _includeFactory.Include(query, include);
            }

            return query;
        }
    }
}