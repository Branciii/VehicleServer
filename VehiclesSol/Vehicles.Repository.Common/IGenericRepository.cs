using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Dal;

namespace Vehicles.Repository.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> FindAsync(IQueryable<T> vehicles, string sortOrder, string sortingAttr, int pageNumber, string searchString, string searchAttr);
        Task<bool> DeleteVehicleAsync(VehicleContext vehicleContext, T vehicle);
    }
}
