using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Common;

namespace Vehicles.Service.Common
{
    public interface IVehicleModelService
    {
        Task<List<Model.VehicleModel>> FindAsync(Filter filter, Sorter sorter, Pager pager);
        Task<bool> AddNewVehicleModelAsync(Model.VehicleModel vehicleModel);
        Task<bool> UpdateVehicleModelNameAsync(Model.VehicleModel vehicleModel);
        Task<bool> DeleteVehicleModelByIdAsync(int id);
    }
}
