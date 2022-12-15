using System;
using System.Collections.Generic;
using System.Linq;
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
        private IFilter<T> Filter { get; set; }
        private ISorter<T> Sorter { get; set; }
        private IPager<T> Pager { get; set; }

        public GenericRepository(IFilter<T> filter,
                                 ISorter<T> sorter,
                                 IPager<T> pager)
        {
            this.Filter = filter;
            this.Sorter = sorter;
            this.Pager = pager;
        }

        public async Task<List<T>> FindAsync(IQueryable<T> vehicles, string sortOrder, string sortingAttr, int pageNumber, string searchString, string searchAttr)
        {
            if (searchString != null && searchString != "")
            {
                if (searchAttr == null)
                    searchAttr = "Name";
                else
                    searchAttr = char.ToUpper(searchAttr.First()) + searchAttr.Substring(1).ToLower();
                vehicles = this.Filter.CreateFilteredList(vehicles, searchString, searchAttr);
            }

            if (sortingAttr == null)
                sortingAttr = "Name";
            else
                sortingAttr = char.ToUpper(sortingAttr.First()) + sortingAttr.Substring(1).ToLower();

            vehicles = this.Sorter.CreateSortedList(vehicles, sortOrder, sortingAttr);

            return await this.Pager.CreatePaginatedListAsync(vehicles.AsNoTracking(), pageNumber);
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
