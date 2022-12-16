using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Service.Common;
using Vehicles.Repository.Common;
using Vehicles.Common;

namespace Vehicles.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private IVehicleMakeRepository VehicleRepository { get; set; }

        public VehicleMakeService(IVehicleMakeRepository vehicleRepository)
        {
            this.VehicleRepository = vehicleRepository;
        }

        public async Task<List<Model.VehicleMake>> FindAsync(Filter filter, Sorter sorter, Pager pager)
        {
            return await this.VehicleRepository.FindAsync(filter, sorter, pager);
        }

        public async Task<bool> AddNewVehicleMakeAsync(Model.VehicleMake vehicleMake)
        {
            return await this.VehicleRepository.AddNewVehicleMakeAsync(vehicleMake);
        }

        public async Task<bool> UpdateVehicleMakeNameAsync(Model.VehicleMake vehicleMake)
        {
            return await this.VehicleRepository.UpdateVehicleMakeNameAsync(vehicleMake);
        }

        public async Task<bool> DeleteVehicleMakeByIdAsync(int id)
        {
            return await this.VehicleRepository.DeleteVehicleMakeByIdAsync(id);
        }
    }
}
