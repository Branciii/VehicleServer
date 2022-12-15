using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Repository.Common;
using Vehicles.Dal;
using System.Data.Entity;
using Vehicles.Common;

namespace Vehicles.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private VehicleContext db = new VehicleContext();
        private IFilter<Model.VehicleMake> Filter { get; set; }
        private ISorter<Model.VehicleMake> Sorter { get; set; }
        private IPager<Model.VehicleMake> Pager { get; set; }

        public VehicleMakeRepository(IFilter<Model.VehicleMake> filter,
                                     ISorter<Model.VehicleMake> sorter,
                                     IPager<Model.VehicleMake> pager)
        {
            this.Filter = filter;
            this.Sorter = sorter;
            this.Pager = pager;
        }

        public async Task<List<Model.VehicleMake>> FindAsync(string sortOrder, string sortingAttr, int pageNumber, string searchString, string searchAttr)
        {
            var vehicleMakes = from vm in db.VehicleMakes
                           select vm;

            if (searchString != null && searchString != "")
            {
                if (searchAttr == null)
                    searchAttr = "Name";
                vehicleMakes = this.Filter.CreateFilteredList(vehicleMakes, searchString, searchAttr);
            }

            if (sortingAttr == null)
                sortingAttr = "Name";
            else
                sortingAttr = char.ToUpper(sortingAttr.First()) + sortingAttr.Substring(1).ToLower();

            vehicleMakes = this.Sorter.CreateSortedList(vehicleMakes, sortOrder, sortingAttr);

            return await this.Pager.CreatePaginatedListAsync(vehicleMakes.AsNoTracking(), pageNumber);
        }

        public async Task<bool> AddNewVehicleMakeAsync(Model.VehicleMake vehicleMakeModel)
        {
            db.VehicleMakes.Add(vehicleMakeModel);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateVehicleMakeNameAsync(Model.VehicleMake vehicleMakeModel)
        {
            var updatedVehicleMakeModel = await db.VehicleMakes.FindAsync(vehicleMakeModel.Id);
            if (updatedVehicleMakeModel == null)
            {
                return false;
            }
            updatedVehicleMakeModel.Name = vehicleMakeModel.Name;
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteVehicleMakeByIdAsync(int id)
        {
            var vehicleMakeModel = await db.VehicleMakes.FindAsync(id);
            if (vehicleMakeModel == null)
                return false;
            db.Entry(vehicleMakeModel).State = EntityState.Deleted;

            // delete models referencing the vehicle make that's being deleted
            var vehicleModels = from vm in db.VehicleModels
                                where vm.MakeId.Equals(id)
                                select vm;
            foreach (Model.VehicleModel vm in vehicleModels)
            {
                db.Entry(vm).State = EntityState.Deleted;
            }

            await db.SaveChangesAsync();
            return true;
        }
    }
}

