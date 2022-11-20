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

        public VehicleMakeModel ReadVehiclesMakeById(int id)
        {
            VehicleMakeModel vehicleMakeModel = db.VehicleMakes.Find(id);

            if (vehicleMakeModel == null)
            {
                return null;
            }
            return vehicleMakeModel;
        }

        public void AddNewVehicleMake(VehicleMakeModel vehicleMakeModel)
        {
            db.VehicleMakes.Add(vehicleMakeModel);
            db.SaveChanges();
        }

        public VehicleMakeModel UpdateVehicleMakeName(VehicleMakeModel vehicleMakeModel)
        {
            VehicleMakeModel updatedVehicleMakeModel = db.VehicleMakes.Find(vehicleMakeModel.Id);
            if (updatedVehicleMakeModel == null)
            {
                return null;
            }
            updatedVehicleMakeModel.Name = vehicleMakeModel.Name;
            db.SaveChanges();
            return updatedVehicleMakeModel;
        }

        public void DeleteVehicleMakeById(int id)
        {
            VehicleMakeModel vehicleMakeModel = db.VehicleMakes.Find(id);
            db.Entry(vehicleMakeModel).State = EntityState.Deleted;

            // delete models referencing the vehicle make that's being deleted
            var vehicleModels = from vm in db.VehicleModels
                                where vm.MakeId.Equals(id)
                                select vm;
            foreach (VehicleModelModel vm in vehicleModels)
            {
                db.Entry(vm).State = EntityState.Deleted;
            }

            db.SaveChanges();
        }
    }
}
