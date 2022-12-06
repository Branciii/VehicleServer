using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Repository.Common;
using Vehicles.Model;
using System.Data.Entity;
using Vehicles.Dal;

namespace Vehicles.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private VehicleContext db = new VehicleContext();
        public DbSet<VehicleModelModel> ReadAllVehicleModels()
        {
            return db.VehicleModels;
        }

        public async Task<VehicleModelModel> ReadVehiclesModelByIdAsync(int id)
        {
            VehicleModelModel vehicleModelModel = await db.VehicleModels.FindAsync(id);

            if (vehicleModelModel == null)
            {
                return null;
            }
            return vehicleModelModel;
        }

        public async Task<List<VehicleModelModel>> ReadSortedVehicleModelsAsync(string sortOrder)
        {
            var vehicleModels = from vm in db.VehicleModels
                                select vm;

            if (sortOrder == "desc")
            {
                vehicleModels = vehicleModels.OrderByDescending(vm => vm.Name);
            }
            else
            {
                vehicleModels = vehicleModels.OrderBy(vm => vm.Name);
            }
            return await vehicleModels.ToListAsync();
        }

        public async Task<List<VehicleModelModel>> ReadVehicleModelsByPageAsync(int pageNumber)
        {
            return await db.VehicleModels.OrderBy(vm => vm.Name).Skip((pageNumber - 1) * 3).Take(3).ToListAsync();
        }

        public async Task<List<VehicleModelModel>> ReadVehicleModelsByLetterAsync(string letter)
        {
            return await db.VehicleModels.Where(vm => vm.Name.Substring(0, letter.Length).ToUpper() == letter.ToUpper()).ToListAsync();
        }

        public async Task<List<VehicleModelModel>> ReadVehicleModelByVehicleMakeNameAsync(string name)
        {
            var MakeId = from vm in db.VehicleMakes
                         where vm.Name.Equals(name)
                         select vm.Id;
            var vehicleModels = await db.VehicleModels.Where(vm => vm.MakeId == MakeId.FirstOrDefault()).ToListAsync();

            return vehicleModels;
        }

        public async Task<bool> AddNewVehicleModelAsync(VehicleModelModel vehicleModelModel)
        {
            db.VehicleModels.Add(vehicleModelModel);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateVehicleModelNameAsync(VehicleModelModel vehicleModelModel)
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
