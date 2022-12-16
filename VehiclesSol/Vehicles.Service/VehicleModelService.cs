using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Service.Common;
using Vehicles.Common;
using Vehicles.Repository.Common;

namespace Vehicles.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        private IVehicleModelRepository VehicleRepository { get; set; }
        public VehicleModelService(IVehicleModelRepository vehicleRepository)
        {
            this.VehicleRepository = vehicleRepository;
        }
        public async Task<List<Model.VehicleModel>> FindAsync(Filter filter, Sorter sorter, Pager pager)
        {
            return await this.VehicleRepository.FindAsync(filter, sorter, pager);
        }

        public async Task<bool> AddNewVehicleModelAsync(Model.VehicleModel vehicleModel)
        {
            return await this.VehicleRepository.AddNewVehicleModelAsync(vehicleModel);
        }

        public async Task<bool> UpdateVehicleModelNameAsync(Model.VehicleModel vehicleModel)
        {
            return await this.VehicleRepository.UpdateVehicleModelNameAsync(vehicleModel);
        }

        public async Task<bool> DeleteVehicleModelByIdAsync(int id)
        {
            return await this.VehicleRepository.DeleteVehicleModelByIdAsync(id);
        }
    }
}
