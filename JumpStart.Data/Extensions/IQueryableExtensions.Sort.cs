using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using System.Linq.Expressions;

namespace System.Linq;

public static partial class IQueryableExtensions
{
    public static IQueryable<Entity> Sort<Entity>(this IQueryable<Entity> queryable, SortedDictionary<string, bool> sortOrder)
    {
        if (sortOrder == null || sortOrder.Count == 0)
            return queryable;

        Type type = typeof(Entity);
        var properties = type
            .GetProperties(System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.Public)
            .ToDictionary(p => p.Name.ToLower(), StringComparer.OrdinalIgnoreCase);
        var parameter = Expression.Parameter(typeof(Entity), "e");

        foreach ((string column, bool ascending) in sortOrder)
        {
            if (string.IsNullOrWhiteSpace(column))
                continue;

            if (properties.TryGetValue(column.ToLower().Trim(), out var property))
            {
                var propertyAccess = Expression.PropertyOrField(parameter, property.Name);
                var lambda = Expression.Lambda(propertyAccess, parameter);
                string methodName = ascending ? "OrderBy" : "OrderByDescending";
                var methodCallExpression = Expression.Call(
                    typeof(Queryable),
                    methodName,
                    new Type[] { type, property.PropertyType },
                    queryable.Expression,
                    Expression.Quote(lambda)
                    );
                queryable = queryable.Provider.CreateQuery<Entity>(methodCallExpression);
            }
        }

        return queryable;
    }
}
