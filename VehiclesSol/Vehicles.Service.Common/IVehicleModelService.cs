using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Vehicles.Service.Common
{
    public interface IVehicleModelService
    {
        Task<List<Model.VehicleModel>> FindAsync(string sortOrder, string sortingAttr, int pageNumber, string searchString, string searchAttr);
        Task<bool> AddNewVehicleModelAsync(Model.VehicleModel vehicleModelModel);
        Task<bool> UpdateVehicleModelNameAsync(Model.VehicleModel vehicleModelModel);
        Task<bool> DeleteVehicleModelByIdAsync(int id);
    }
}
