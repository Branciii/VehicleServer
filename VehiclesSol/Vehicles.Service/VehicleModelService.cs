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
        public async Task<List<Model.VehicleModel>> FindAsync(string sortOrder, int pageNumber, string searchString)
        {
            return await this.VehicleRepository.FindAsync(sortOrder, pageNumber, searchString);
        }
        public DbSet<Model.VehicleModel> ReadAllVehicleModels()
        {
            return this.VehicleRepository.ReadAllVehicleModels();
        }

        public async Task<Model.VehicleModel> ReadVehiclesModelByIdAsync(int id)
        {
            return await this.VehicleRepository.ReadVehiclesModelByIdAsync(id);
        }

        public async Task<List<Model.VehicleModel>> ReadVehicleModelsByLetterAsync(string letter)
        {
            return await this.VehicleRepository.ReadVehicleModelsByLetterAsync(letter);
        }

        public async Task<List<Model.VehicleModel>> ReadVehicleModelByVehicleMakeNameAsync(string name)
        {
            return await this.VehicleRepository.ReadVehicleModelByVehicleMakeNameAsync(name);
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
