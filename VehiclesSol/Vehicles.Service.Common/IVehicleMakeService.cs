using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Vehicles.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<List<Model.VehicleMake>> FindAsync(string sortOrder, string sortingAttr, int pageNumber, string searchString, string searchAttr);
        Task<bool> AddNewVehicleMakeAsync(Model.VehicleMake vehicleMake);
        Task<bool> UpdateVehicleMakeNameAsync(Model.VehicleMake vehicleMake);
        Task<bool> DeleteVehicleMakeByIdAsync(int id);
    }
}
