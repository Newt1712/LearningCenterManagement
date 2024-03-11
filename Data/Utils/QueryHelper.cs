using System.Linq.Expressions;

namespace Data.Utils;

public static class QueryHelper
{
    public static bool IsDescendingSort(string sort)
    {
        var isDesc = string.IsNullOrEmpty(sort) ? true : sort.ToLower().Equals("desc") ? true : false;
        return isDesc;
    }

    public static IQueryable<TEntity> DynamicOrderBy<TEntity>(this IQueryable<TEntity> source, string orderByProperty,
        bool desc)
    {
        var command = desc ? "OrderByDescending" : "OrderBy";
        var type = typeof(TEntity);
        var property = type.GetProperty(orderByProperty);
        var parameter = Expression.Parameter(type, "p");
        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        var orderByExpression = Expression.Lambda(propertyAccess, parameter);
        var resultExpression = Expression.Call(typeof(Queryable), command, new[] { type, property.PropertyType },
            source.Expression, Expression.Quote(orderByExpression));
        return source.Provider.CreateQuery<TEntity>(resultExpression);
    }
}