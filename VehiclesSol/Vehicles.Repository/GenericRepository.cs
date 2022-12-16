using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Repository.Common;
using Vehicles.Common;
using System.Data.Entity;
using Vehicles.Dal;

namespace Vehicles.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public async Task<List<T>> FindAsync(IQueryable<T> vehicles, Filter filter, Sorter sorter, Pager pager)
        {
            if (filter != null)
            {
                if (filter.SearchString != null && filter.SearchString != "")
                {
                    if (filter.SearchAttr == null)
                        filter.SearchAttr = "Name";
                    else
                        filter.SearchAttr = char.ToUpper(filter.SearchAttr.First()) + filter.SearchAttr.Substring(1).ToLower();
                    vehicles = CreateFilteredList(vehicles, filter.SearchString, filter.SearchAttr);
                }
            }

            if (sorter != null)
            {
                if (sorter.SortingAttr == null)
                    sorter.SortingAttr = "Name";
                else
                    sorter.SortingAttr = char.ToUpper(sorter.SortingAttr.First()) + sorter.SortingAttr.Substring(1).ToLower();

                vehicles = CreateSortedList(vehicles, sorter.SortingOrder, sorter.SortingAttr);
            }
            else
                vehicles = CreateSortedList(vehicles, "asc", "Name");

            if (pager!=null)
                return await vehicles.Skip((pager.PageNumber - 1) * 3).Take(3).ToListAsync();
            else
                return await vehicles.Skip(0).Take(3).ToListAsync();
        }

        public IQueryable<T> CreateFilteredList(IQueryable<T> vehicles, string searchString, string searchAttr)
        {
            Type entityType = typeof(T);
            ParameterExpression arg = Expression.Parameter(entityType, "x");
            MethodInfo containsMethod = typeof(string).GetMethod("Contains");

            MemberExpression property = Expression.Property(arg, searchAttr);

            MethodCallExpression call = Expression.Call(property, containsMethod, Expression.Constant(searchString.ToLower()));

            Expression<Func<T, bool>> selector = Expression.Lambda<Func<T, bool>>(
                            Expression.AndAlso(
                                Expression.NotEqual(property, Expression.Constant(null)),
                                call
                            ),
                            arg
                        );

            return vehicles.Where(selector);
        }

        public IOrderedQueryable<T> CreateSortedList(IQueryable<T> vehicles, string sortingOrder, string sortingAttr)
        {
            Type entityType = typeof(T);
            PropertyInfo propertyInfo = entityType.GetProperty(sortingAttr);
            ParameterExpression arg = Expression.Parameter(entityType, "x");
            MemberExpression property = Expression.Property(arg, sortingAttr);

            var selector = Expression.Lambda(property, new ParameterExpression[] { arg });

            if (sortingOrder != null && sortingOrder.ToLower() == "desc")
                sortingOrder = "OrderByDescending";
            else
                sortingOrder = "OrderBy";

            MethodInfo method = typeof(Queryable).GetMethods()
                 .Where(m => m.Name == sortingOrder)
                 .Where(m =>
                 {
                     List<ParameterInfo> parameters = m.GetParameters().ToList();
                     return parameters.Count == 2;
                 }).Single();

            MethodInfo genericMethod = method.MakeGenericMethod(entityType, propertyInfo.PropertyType);

            return (IOrderedQueryable<T>)genericMethod.Invoke(genericMethod, new object[] { vehicles, selector });
        }

        public async Task<bool> DeleteVehicleAsync(VehicleContext vehicleContext, T vehicle)
        {
            if (vehicle == null)
                return false;
            vehicleContext.Entry(vehicle).State = EntityState.Deleted;
            await vehicleContext.SaveChangesAsync();
            return true;
        }

    }
}
