using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanArchitecture.Common.Areas.Invariance;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Models;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Specifications;

namespace Mmu.CleanArchitecture.DataAccess.Areas.Querying.Services.Servants.Implementation
{
    public class IncludeFactory : IIncludeFactory
    {
        public IQueryable<TEntity> Include<TEntity>(IQueryable<TEntity> source, IncludeExpressionInfo info)
        where TEntity: EntityBase
        {
            Guard.ObjectNotNull(() => source);
            Guard.ObjectNotNull(() => info);
            
            return info.Type == IncludeType.Include ?
                AddInclude(source, info) :
                AddThenInclude(source, info);
        }

        private static IQueryable<TEntity> AddInclude<TEntity>(IQueryable<TEntity> source, IncludeExpressionInfo info)
        where TEntity:EntityBase
        {
            var propertyName = GetPropertyName(info.LambdaExpression);

            return source.Include(propertyName);
        }

        private static IQueryable<TEntity> AddThenInclude<TEntity>(IQueryable<TEntity> source, IncludeExpressionInfo info)
        where TEntity:EntityBase
        {
            var exp = source.Expression as MethodCallExpression;
            var arg = exp.Arguments[0] as ConstantExpression;

            string previousPropertyName;
            if (arg.Value is string)
            {
                previousPropertyName = arg.Value.ToString();
            }
            else
            {
                // System.Data.Entity.Core.Objects.Span is an internal class, so here's some reflection to get to the previous property.
                var propertyInfo = arg.Value.GetType().GetProperty("SpanList", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                var spanList = propertyInfo.GetValue(arg.Value);

                // Get the first item of the span list
                propertyInfo = propertyInfo.PropertyType.GetProperty("Item");
                var spanPath = propertyInfo.GetValue(spanList, new object[] { 0 });

                var fieldInfo = spanPath.GetType().GetField("Navigations", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                var navigations = fieldInfo.GetValue(spanPath) as List<string>;
                previousPropertyName = string.Join(".", navigations);
            }
            
            var propertyName = GetPropertyName(info.LambdaExpression);

            return source.Include($"{previousPropertyName}.{propertyName}");
        }

        private static string GetPropertyName(Expression propertySelector, char delimiter = '.', char endTrim = ')')
        {

            var asString = propertySelector.ToString();
            var firstDelim = asString.IndexOf(delimiter);

            return firstDelim < 0
                ? asString
                : asString.Substring(firstDelim + 1).TrimEnd(endTrim);
        }
    }
}