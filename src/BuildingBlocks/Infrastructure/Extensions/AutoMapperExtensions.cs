using System.Reflection;
using AutoMapper;

namespace Infrastructure.Extensions;

public static class AutoMapperExtensions
{
    // Quét qua tất cả các properties của Source và Destination, nếu trong Source và Des ko chung property nào thì sẽ ignore property đó
    // Lí do:
    public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>
        (this IMappingExpression<TSource, TDestination> expression)
    {
        var flags = BindingFlags.Public | BindingFlags.Instance;
        var sourceType = typeof(TSource);
        var destinationProperties = typeof(TDestination).GetProperties(flags);

        foreach (var property in destinationProperties)
            if (sourceType.GetProperty(property.Name, flags) == null)
                expression.ForMember(property.Name, opt => opt.Ignore());
        return expression;
    }

    //public static Task<PagedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageIndex, int pageSize) where TDestination : class
    //    => PagedList<TDestination>.ToPagedList(queryable, pageIndex, pageSize);
}