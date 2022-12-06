using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Vehicles.Model;

namespace Vehicles.Repository.Common
{
    public interface IVehicleModelRepository
    {
        DbSet<VehicleModelModel> ReadAllVehicleModels();
        Task<VehicleModelModel> ReadVehiclesModelByIdAsync(int id);
        Task<List<VehicleModelModel>> ReadSortedVehicleModelsAsync(string sortOrder);
        Task<List<VehicleModelModel>> ReadVehicleModelsByPageAsync(int pageNumber);
        Task<List<VehicleModelModel>> ReadVehicleModelsByLetterAsync(string letter);
        Task<List<VehicleModelModel>> ReadVehicleModelByVehicleMakeNameAsync(string name);
        Task<bool> AddNewVehicleModelAsync(VehicleModelModel vehicleModelModel);
        Task<bool> UpdateVehicleModelNameAsync(VehicleModelModel vehicleModelModel);
        Task<bool> DeleteVehicleModelByIdAsync(int id);
    }
}
