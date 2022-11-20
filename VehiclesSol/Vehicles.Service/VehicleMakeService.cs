using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Service.Common;
using Vehicles.Model;
using Vehicles.Dal;
using System.Data.Entity;

namespace Vehicles.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private VehicleContext db = new VehicleContext();
        public DbSet<VehicleMakeModel> ReadAllVehicleMakes()
        {
            return db.VehicleMakes;
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
