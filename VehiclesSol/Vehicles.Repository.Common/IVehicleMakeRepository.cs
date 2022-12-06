using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Model;
using System.Data.Entity;

namespace Vehicles.Repository.Common
{
    public interface IVehicleMakeRepository
    {
        DbSet<VehicleMakeModel> ReadAllVehicleMakes();
        Task<List<VehicleMakeModel>> ReadSortedVehicleMakesAsync(string sortOrder);
        Task<List<VehicleMakeModel>> ReadVehicleMakesByPageAsync(int pageNumber);
        Task<List<VehicleMakeModel>> ReadVehicleMakesByLetterAsync(string letter);
        Task<VehicleMakeModel> ReadVehiclesMakeByIdAsync(int id);
        Task<bool> AddNewVehicleMakeAsync(VehicleMakeModel vehicleMakeModel);
        Task<bool> UpdateVehicleMakeNameAsync(VehicleMakeModel vehicleMakeModel);
        Task<bool> DeleteVehicleMakeByIdAsync(int id);
    }
}
