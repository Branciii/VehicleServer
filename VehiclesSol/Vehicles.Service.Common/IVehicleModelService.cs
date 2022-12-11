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
        DbSet<VehicleModelModel> ReadAllVehicleModels();
        Task<List<VehicleModelModel>> FindAsync(string sortOrder, int pageNumber, string searchString);
        Task<VehicleModelModel> ReadVehiclesModelByIdAsync(int id);
        Task<List<VehicleModelModel>> ReadVehicleModelsByLetterAsync(string letter);
        Task<List<VehicleModelModel>> ReadVehicleModelByVehicleMakeNameAsync(string name);
        Task<bool> AddNewVehicleModelAsync(VehicleModelModel vehicleModelModel);
        Task<bool> UpdateVehicleModelNameAsync(VehicleModelModel vehicleModelModel);
        Task<bool> DeleteVehicleModelByIdAsync(int id);
    }
}
