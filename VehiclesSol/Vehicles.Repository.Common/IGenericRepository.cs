using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Dal;
using Vehicles.Common;

namespace Vehicles.Repository.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> FindAsync(IQueryable<T> vehicles, Filter filter, Sorter sorter, Pager pager);
        IQueryable<T> CreateFilteredList(IQueryable<T> vehicles, string searchString, string searchAttr);
        IOrderedQueryable<T> CreateSortedList(IQueryable<T> vehicles, string sortingOrder, string sortingAttr);
        Task<bool> DeleteVehicleAsync(VehicleContext vehicleContext, T vehicle);
    }
}
