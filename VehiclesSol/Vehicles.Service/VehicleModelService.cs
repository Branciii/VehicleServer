using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Service.Common;
using System.Data.Entity;
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
        public async Task<List<Model.VehicleModel>> FindAsync(string sortOrder, string sortingAttr, int pageNumber, string searchString, string searchAttr)
        {
            return await this.VehicleRepository.FindAsync(sortOrder, sortingAttr, pageNumber, searchString, searchAttr);
        }

        public async Task<bool> AddNewVehicleModelAsync(Model.VehicleModel vehicleModelModel)
        {
            return await this.VehicleRepository.AddNewVehicleModelAsync(vehicleModelModel);
        }

        public async Task<bool> UpdateVehicleModelNameAsync(Model.VehicleModel vehicleModelModel)
        {
            return await this.VehicleRepository.UpdateVehicleModelNameAsync(vehicleModelModel);
        }

        public async Task<bool> DeleteVehicleModelByIdAsync(int id)
        {
            return await this.VehicleRepository.DeleteVehicleModelByIdAsync(id);
        }
    }
}
