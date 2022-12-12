﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Service.Common;
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

        public async Task<List<Model.VehicleMake>> FindAsync(string sortOrder, int pageNumber, string searchString)
        {
            return await this.VehicleRepository.FindAsync(sortOrder, pageNumber, searchString);
        }

        public async Task<List<Model.VehicleMake>> ReadAllVehicleMakesAsync()
        {
            return await this.VehicleRepository.ReadAllVehicleMakesAsync();
        }

        public async Task<List<Model.VehicleMake>> ReadVehicleMakesByLetterAsync(string letter)
        {
            return await this.VehicleRepository.ReadVehicleMakesByLetterAsync(letter);
        }

        public async Task<Model.VehicleMake> ReadVehiclesMakeByIdAsync(int id)
        {
            return await this.VehicleRepository.ReadVehiclesMakeByIdAsync(id);
        }

        public async Task<bool> AddNewVehicleMakeAsync(Model.VehicleMake vehicleMakeModel)
        {
            return await this.VehicleRepository.AddNewVehicleMakeAsync(vehicleMakeModel);
        }

        public async Task<bool> UpdateVehicleMakeNameAsync(Model.VehicleMake vehicleMakeModel)
        {
            return await this.VehicleRepository.UpdateVehicleMakeNameAsync(vehicleMakeModel);
        }

        public async Task<bool> DeleteVehicleMakeByIdAsync(int id)
        {
            return await this.VehicleRepository.DeleteVehicleMakeByIdAsync(id);
        }
    }
}
