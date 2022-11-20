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

        public VehicleModelModel ReadVehiclesModelById(int id)
        {
            VehicleModelModel vehicleModelModel = db.VehicleModels.Find(id);

            if (vehicleModelModel == null)
            {
                return null;
            }
            return vehicleModelModel;
        }

        public void AddNewVehicleModel(VehicleModelModel vehicleModelModel)
        {
            db.VehicleModels.Add(vehicleModelModel);
            db.SaveChanges();
        }

        public VehicleModelModel UpdateVehicleModelName(VehicleModelModel vehicleModelModel)
        {
            VehicleModelModel updatedVehicleModelModel = db.VehicleModels.Find(vehicleModelModel.Id);
            if (updatedVehicleModelModel == null)
            {
                return null;
            }
            updatedVehicleModelModel.Name = vehicleModelModel.Name;
            db.SaveChanges();
            return updatedVehicleModelModel;
        }

        public void DeleteVehicleModelById(int id)
        {
            VehicleModelModel vehicleModelModel = db.VehicleModels.Find(id);
            db.Entry(vehicleModelModel).State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
}
