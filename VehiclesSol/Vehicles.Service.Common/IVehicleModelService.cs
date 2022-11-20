using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Vehicles.Model;

namespace Vehicles.Service.Common
{
    public interface IVehicleModelService
    {
        DbSet<VehicleModelModel> ReadAllVehicleMakes();
        VehicleModelModel ReadVehiclesModelById(int id);
        void AddNewVehicleModel(VehicleModelModel vehicleModelModel);
        VehicleModelModel UpdateVehicleModelName(VehicleModelModel vehicleModelModel);
        void DeleteVehicleModelById(int id);
    }
}
