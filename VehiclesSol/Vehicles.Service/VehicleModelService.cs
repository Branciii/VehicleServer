using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Service.Common;
using Vehicles.Model;
using System.Data.Entity;
using Vehicles.Dal;

namespace Vehicles.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        private VehicleContext db = new VehicleContext();
        public DbSet<VehicleModelModel> ReadAllVehicleMakes()
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
