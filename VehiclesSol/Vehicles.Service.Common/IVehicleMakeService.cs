using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Vehicles.Model;

namespace Vehicles.Service.Common
{
    public interface IVehicleMakeService
    {
        DbSet<VehicleMakeModel> ReadAllVehicleMakes();
        VehicleMakeModel ReadVehiclesMakeById(int id);
        void AddNewVehicleMake(VehicleMakeModel vehicleMakeModel);
        VehicleMakeModel UpdateVehicleMakeName(VehicleMakeModel vehicleMakeModel);
        void DeleteVehicleMakeById(int id);

    }
}
