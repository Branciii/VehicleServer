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
    public class VehicleMakeService : IVehicleMakeService
    {
        private IVehicleMakeRepository VehicleRepository { get; set; }

        public VehicleMakeService(IVehicleMakeRepository vehicleRepository)
        {
            this.VehicleRepository = vehicleRepository;
        }

        public async Task<List<VehicleMakeModel>> FindAsync(string sortOrder, int pageNumber, string searchString)
        {
            return await this.VehicleRepository.FindAsync(sortOrder, pageNumber, searchString);
        }

        public DbSet<VehicleMakeModel> ReadAllVehicleMakes()
        {
            return this.VehicleRepository.ReadAllVehicleMakes();
        }

        public async Task<List<VehicleMakeModel>> ReadSortedVehicleMakesAsync(string sortOrder)
        {
            return await this.VehicleRepository.ReadSortedVehicleMakesAsync(sortOrder);
        }

        public async Task<List<VehicleMakeModel>> ReadVehicleMakesByPageAsync(int pageNumber)
        {
            return await this.VehicleRepository.ReadVehicleMakesByPageAsync(pageNumber);
        }

        public async Task<List<VehicleMakeModel>> ReadVehicleMakesByLetterAsync(string letter)
        {
            return await this.VehicleRepository.ReadVehicleMakesByLetterAsync(letter);
        }

        public async Task<VehicleMakeModel> ReadVehiclesMakeByIdAsync(int id)
        {
            return await this.VehicleRepository.ReadVehiclesMakeByIdAsync(id);
        }

        public async Task<bool> AddNewVehicleMakeAsync(VehicleMakeModel vehicleMakeModel)
        {
            return await this.VehicleRepository.AddNewVehicleMakeAsync(vehicleMakeModel);
        }

        public async Task<bool> UpdateVehicleMakeNameAsync(VehicleMakeModel vehicleMakeModel)
        {
            return await this.VehicleRepository.UpdateVehicleMakeNameAsync(vehicleMakeModel);
        }

        public async Task<bool> DeleteVehicleMakeByIdAsync(int id)
        {
            return await this.VehicleRepository.DeleteVehicleMakeByIdAsync(id);
        }
    }
}
