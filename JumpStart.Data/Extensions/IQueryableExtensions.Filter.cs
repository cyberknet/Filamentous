using JumpStart.Api.Filtering;
using JumpStart.Data.Entities.Base;
using System.Linq.Expressions;

namespace System.Linq;

public static partial class IQueryableExtensions
{

    public static IQueryable<TEntity> Filter<TEntity>(this IQueryable<TEntity> query, List<FilterCriteria> filterCriteria)
            where TEntity : Entity
    {
        if (filterCriteria != null && filterCriteria.Any())
        {
            var predicate = BuildFilterPredicate<TEntity>(filterCriteria);
            query = query.Where(predicate);
        }
        return query;
    }

    private static Expression<Func<TEntity, bool>> BuildFilterPredicate<TEntity>(List<FilterCriteria> filterCriteria)
            where TEntity : Entity
    {
        var parameter = Expression.Parameter(typeof(TEntity));
        var predicate = BuildPredicate(parameter, filterCriteria);
        return Expression.Lambda<Func<TEntity, bool>>(predicate, parameter);
    }

    private static Expression BuildPredicate(ParameterExpression parameter, List<FilterCriteria> filterCriteria)
    {
        Expression result = null;
        foreach (var criteria in filterCriteria)
        {
            Expression condition;

            if (criteria.Operator == FilterOperator.In)
            {
                var property = Expression.Property(parameter, criteria.PropertyName);
                var valueList = criteria.Values.Select(value => Expression.Constant(value));
                var containsMethod = typeof(Enumerable).GetMethods()
                    .Where(method => method.Name == "Contains" && method.GetParameters().Length == 2)
                    .First()
                    .MakeGenericMethod(property.Type);
                var call = Expression.Call(null, containsMethod, Expression.Constant(criteria.Values), property);
                condition = call;
            }
            else
            {
                var property = Expression.Property(parameter, criteria.PropertyName);
                var value = Expression.Constant(criteria.Value);

                switch (criteria.Operator)
                {
                    case FilterOperator.Equal:
                        condition = Expression.Equal(property, value);
                        break;
                    case FilterOperator.NotEqual:
                        condition = Expression.NotEqual(property, value);
                        break;
                    case FilterOperator.GreaterThan:
                        condition = Expression.GreaterThan(property, value);
                        break;
                    case FilterOperator.GreaterThanOrEqual:
                        condition = Expression.GreaterThanOrEqual(property, value);
                        break;
                    case FilterOperator.LessThan:
                        condition = Expression.LessThan(property, value);
                        break;
                    case FilterOperator.LessThanOrEqual:
                        condition = Expression.LessThanOrEqual(property, value);
                        break;
                    case FilterOperator.Contains:
                        condition = Expression.Call(property, typeof(string).GetMethod("Contains", new[] { typeof(string) }), value);
                        break;
                    case FilterOperator.StartsWith:
                        condition = Expression.Call(property, typeof(string).GetMethod("StartsWith", new[] { typeof(string) }), value);
                        break;
                    case FilterOperator.EndsWith:
                        condition = Expression.Call(property, typeof(string).GetMethod("EndsWith", new[] { typeof(string) }), value);
                        break;
                    default:
                        throw new NotSupportedException($"Operator '{criteria.Operator}' is not supported.");
                }
            }

            if (result == null)
                result = condition;
            else
                result = criteria.Logic == FilterLogic.And ? Expression.AndAlso(result, condition) : Expression.OrElse(result, condition);
        }

        return result;
    }
}
