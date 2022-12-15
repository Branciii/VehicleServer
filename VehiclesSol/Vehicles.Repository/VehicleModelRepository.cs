using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Repository.Common;
using System.Data.Entity;
using Vehicles.Dal;
using Vehicles.Common;

namespace Vehicles.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private VehicleContext db = new VehicleContext();

        private IFilter<Model.VehicleModel> Filter { get; set; }
        private ISorter<Model.VehicleModel> Sorter { get; set; }
        private IPager<Model.VehicleModel> Pager { get; set; }

        public VehicleModelRepository(IFilter<Model.VehicleModel> filter,
                                      ISorter<Model.VehicleModel> sorter,
                                      IPager<Model.VehicleModel> pager)
        {
            this.Filter = filter;
            this.Sorter = sorter;
            this.Pager = pager;
        }
        public async Task<List<Model.VehicleModel>> FindAsync(string sortOrder, string sortingAttr, int pageNumber, string searchString, string searchAttr)
        {
            var vehicleModels = from vm in db.VehicleModels
                               select vm;
            if (searchString != null && searchString != "")
            {
                if (searchAttr == null)
                    searchAttr = "Name";
                else
                    searchAttr = char.ToUpper(searchAttr.First()) + searchAttr.Substring(1).ToLower();
                vehicleModels = this.Filter.CreateFilteredList(vehicleModels, searchString, searchAttr);
            }

            if (sortingAttr == null)
                sortingAttr = "Name";
            else
                sortingAttr = char.ToUpper(sortingAttr.First()) + sortingAttr.Substring(1).ToLower();

            vehicleModels = this.Sorter.CreateSortedList(vehicleModels, sortOrder, sortingAttr);

            return await this.Pager.CreatePaginatedListAsync(vehicleModels.AsNoTracking(), pageNumber);
        }

        public async Task<bool> AddNewVehicleModelAsync(Model.VehicleModel vehicleModelModel)
        {
            db.VehicleModels.Add(vehicleModelModel);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateVehicleModelNameAsync(Model.VehicleModel vehicleModelModel)
        {
            var updatedVehicleModelModel = await db.VehicleModels.FindAsync(vehicleModelModel.Id);
            if (updatedVehicleModelModel == null)
            {
                return false;
            }
            updatedVehicleModelModel.Name = vehicleModelModel.Name;
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteVehicleModelByIdAsync(int id)
        {
            var vehicleModelModel = await db.VehicleModels.FindAsync(id);
            if (vehicleModelModel == null)
                return false;
            db.Entry(vehicleModelModel).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return true;
        }
    }
}
