using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Common
{
    public class Sorter<T>
    {
        public IOrderedQueryable<T> CreatePaginatedListAsync(IQueryable<T> vehicles, string sortOrder, string sortingAttr)
        {
            var entityType = typeof(T);
            var propertyInfo = entityType.GetProperty(sortingAttr);
            ParameterExpression arg = Expression.Parameter(entityType, "x");
            MemberExpression property = Expression.Property(arg, sortingAttr);

            var selector = Expression.Lambda(property, new ParameterExpression[] { arg });

            if (sortOrder != null && sortOrder.ToLower() == "desc")
                sortOrder = "OrderByDescending";
            else
                sortOrder = "OrderBy";

            var enumarableType = typeof(Queryable);
            var method = enumarableType.GetMethods()
                 .Where(m => m.Name == sortOrder && m.IsGenericMethodDefinition)
                 .Where(m =>
                 {
                     var parameters = m.GetParameters().ToList();
                     return parameters.Count == 2;
                 }).Single();


            MethodInfo genericMethod = method
                 .MakeGenericMethod(entityType, propertyInfo.PropertyType);

            return (IOrderedQueryable<T>)genericMethod.Invoke(genericMethod, new object[] { vehicles, selector });
        }

    }
}
