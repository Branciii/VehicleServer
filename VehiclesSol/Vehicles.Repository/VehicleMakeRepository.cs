using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Repository.Common;
using Vehicles.Dal;
using System.Data.Entity;
using Vehicles.Model;
using Vehicles.Common;

namespace Vehicles.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private VehicleContext db = new VehicleContext();
        public DbSet<VehicleMakeModel> ReadAllVehicleMakes()
        {
            return db.VehicleMakes;
        }
        public async Task<List<VehicleMakeModel>> FindAsync(string sortOrder, int pageNumber, string searchString)
        {
            var vehicleMakes = from vm in db.VehicleMakes
                           select vm;
            if (searchString != null)
            {
                vehicleMakes = vehicleMakes.Where(vm => vm.Name.ToLower().Contains(searchString.ToLower()));
            }

            if (sortOrder.ToLower() == "desc")
                vehicleMakes = vehicleMakes.OrderByDescending(vm => vm.Name);
            else
                vehicleMakes = vehicleMakes.OrderBy(vm => vm.Name);

            Pager<VehicleMakeModel> pager = new Pager<VehicleMakeModel>();
            return await pager.CreatePaginatedListAsync(vehicleMakes.AsNoTracking(), pageNumber);
        }

        public async Task<List<VehicleMakeModel>> ReadSortedVehicleMakesAsync(string sortOrder)
        {
            var vehicleMakes = from vm in db.VehicleMakes
                               select vm;

            if (sortOrder == "desc")
            {
                vehicleMakes = vehicleMakes.OrderByDescending(vm => vm.Name);
            }
            else
            {
                vehicleMakes = vehicleMakes.OrderBy(vm => vm.Name);
            }
            return await vehicleMakes.ToListAsync();
        }

        public async Task<List<VehicleMakeModel>> ReadVehicleMakesByPageAsync(int pageNumber)
        {
            return await db.VehicleMakes.OrderBy(vm => vm.Name).Skip((pageNumber - 1) * 3).Take(3).ToListAsync();
        }

        public async Task<List<VehicleMakeModel>> ReadVehicleMakesByLetterAsync(string letter)
        {
            return await db.VehicleMakes.Where(vm => vm.Name.Substring(0, letter.Length).ToUpper() == letter.ToUpper()).ToListAsync();
        }

        public async Task<VehicleMakeModel> ReadVehiclesMakeByIdAsync(int id)
        {
            VehicleMakeModel vehicleMakeModel = await db.VehicleMakes.FindAsync(id);

            if (vehicleMakeModel == null)
            {
                return null;
            }
            return vehicleMakeModel;
        }

        public async Task<bool> AddNewVehicleMakeAsync(VehicleMakeModel vehicleMakeModel)
        {
            db.VehicleMakes.Add(vehicleMakeModel);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateVehicleMakeNameAsync(VehicleMakeModel vehicleMakeModel)
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
            foreach (VehicleModelModel vm in vehicleModels)
            {
                db.Entry(vm).State = EntityState.Deleted;
            }

            await db.SaveChangesAsync();
            return true;
        }
    }
}

