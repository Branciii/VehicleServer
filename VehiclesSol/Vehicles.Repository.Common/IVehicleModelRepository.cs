using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Vehicles.Repository.Common
{
    public interface IVehicleModelRepository
    {
        Task<List<Model.VehicleModel>> ReadAllVehicleModelsAsync();
        Task<List<Model.VehicleModel>> FindAsync(string sortOrder, int pageNumber, string searchString);
        Task<Model.VehicleModel> ReadVehiclesModelByIdAsync(int id);
        Task<List<Model.VehicleModel>> ReadVehicleModelsByLetterAsync(string letter);
        Task<List<Model.VehicleModel>> ReadVehicleModelByVehicleMakeNameAsync(string name);
        Task<bool> AddNewVehicleModelAsync(Model.VehicleModel vehicleModelModel);
        Task<bool> UpdateVehicleModelNameAsync(Model.VehicleModel vehicleModelModel);
        Task<bool> DeleteVehicleModelByIdAsync(int id);
    }
}
