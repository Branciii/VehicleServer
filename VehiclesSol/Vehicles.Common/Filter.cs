using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Vehicles.Common
{
    public class Filter<T> : IFilter<T>
    {
        public IQueryable<T> CreateFilteredList(IQueryable<T> vehicles, string searchString, string searchAttr)
        {
            var entityType = typeof(T);
            ParameterExpression arg = Expression.Parameter(entityType, "x");
            MethodInfo containsMethod = typeof(string).GetMethod("Contains"); //method
            var call = Expression.Call(Expression.Property(arg, searchAttr), containsMethod, Expression.Constant(searchString.ToLower()));
            MemberExpression property = Expression.Property(arg, searchAttr);

            Expression<Func<T, bool>> selector = Expression.Lambda<Func<T, bool>> (
                            Expression.AndAlso(
                                Expression.NotEqual(property, Expression.Constant(null)),
                                call
                            ),
                            arg
                        ); 
        
            return vehicles.Where(selector);
        }
    }
}
