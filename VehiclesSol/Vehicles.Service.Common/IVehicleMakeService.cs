using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Common;

namespace Vehicles.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<List<Model.VehicleMake>> FindAsync(Filter filter, Sorter sorter, Pager pager);
        Task<bool> AddNewVehicleMakeAsync(Model.VehicleMake vehicleMake);
        Task<bool> UpdateVehicleMakeNameAsync(Model.VehicleMake vehicleMake);
        Task<bool> DeleteVehicleMakeByIdAsync(int id);
    }
}
