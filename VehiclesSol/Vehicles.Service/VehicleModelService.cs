using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Service.Common;
using Vehicles.Model;
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
        public async Task<List<VehicleModelModel>> FindAsync(string sortOrder, int pageNumber, string searchString)
        {
            return await this.VehicleRepository.FindAsync(sortOrder, pageNumber, searchString);
        }
        public DbSet<VehicleModelModel> ReadAllVehicleModels()
        {
            return this.VehicleRepository.ReadAllVehicleModels();
        }

        public async Task<VehicleModelModel> ReadVehiclesModelByIdAsync(int id)
        {
            return await this.VehicleRepository.ReadVehiclesModelByIdAsync(id);
        }

        public async Task<List<VehicleModelModel>> ReadVehicleModelsByLetterAsync(string letter)
        {
            return await this.VehicleRepository.ReadVehicleModelsByLetterAsync(letter);
        }

        public async Task<List<VehicleModelModel>> ReadVehicleModelByVehicleMakeNameAsync(string name)
        {
            return await this.VehicleRepository.ReadVehicleModelByVehicleMakeNameAsync(name);
        }

        public async Task<bool> AddNewVehicleModelAsync(VehicleModelModel vehicleModelModel)
        {
            return await this.VehicleRepository.AddNewVehicleModelAsync(vehicleModelModel);
        }

        public async Task<bool> UpdateVehicleModelNameAsync(VehicleModelModel vehicleModelModel)
        {
            return await this.VehicleRepository.UpdateVehicleModelNameAsync(vehicleModelModel);
        }

        public async Task<bool> DeleteVehicleModelByIdAsync(int id)
        {
            return await this.VehicleRepository.DeleteVehicleModelByIdAsync(id);
        }
    }
}
