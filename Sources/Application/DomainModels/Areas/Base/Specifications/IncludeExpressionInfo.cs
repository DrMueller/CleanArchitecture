using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.CleanArchitecture.DomainModels.Areas.Base.Specifications
{
    public class IncludeExpressionInfo
    {
        public LambdaExpression LambdaExpression { get; }
        public Type EntityType { get; }
        public Type PropertyType { get; }
        public Type? PreviousPropertyType { get; }
        public IncludeType Type { get; }

        private IncludeExpressionInfo(LambdaExpression expression,
            Type entityType,
            Type propertyType,
            Type? previousPropertyType,
            IncludeType includeType)

        {
            _ = expression ?? throw new ArgumentNullException(nameof(expression));
            _ = entityType ?? throw new ArgumentNullException(nameof(entityType));
            _ = propertyType ?? throw new ArgumentNullException(nameof(propertyType));

            if (includeType == IncludeType.ThenInclude)
            {
                _ = previousPropertyType ?? throw new ArgumentNullException(nameof(previousPropertyType));
            }

            this.LambdaExpression = expression;
            this.EntityType = entityType;
            this.PropertyType = propertyType;
            this.PreviousPropertyType = previousPropertyType;
            this.Type = includeType;
        }

        public IncludeExpressionInfo(LambdaExpression expression,
            Type entityType,
            Type propertyType)
            : this(expression, entityType, propertyType, null, IncludeType.Include)
        {
        }

        public IncludeExpressionInfo(LambdaExpression expression,
            Type entityType,
            Type propertyType,
            Type previousPropertyType)
            : this(expression, entityType, propertyType, previousPropertyType, IncludeType.ThenInclude)
        {
        }
    }
}
