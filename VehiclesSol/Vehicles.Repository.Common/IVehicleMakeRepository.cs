using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Vehicles.Repository.Common
{
    public interface IVehicleMakeRepository
    {
        Task<List<Model.VehicleMake>> FindAsync(string sortOrder, string sortingAttr, int pageNumber, string searchString);
        Task<bool> AddNewVehicleMakeAsync(Model.VehicleMake vehicleMakeModel);
        Task<bool> UpdateVehicleMakeNameAsync(Model.VehicleMake vehicleMakeModel);
        Task<bool> DeleteVehicleMakeByIdAsync(int id);
    }
}
