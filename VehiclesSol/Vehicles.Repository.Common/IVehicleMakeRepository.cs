﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Vehicles.Repository.Common
{
    public interface IVehicleMakeRepository
    {
        DbSet<Model.VehicleMake> ReadAllVehicleMakes();
        Task<List<Model.VehicleMake>> FindAsync(string sortOrder, int pageNumber, string searchString);
        Task<List<Model.VehicleMake>> ReadVehicleMakesByLetterAsync(string letter);
        Task<Model.VehicleMake> ReadVehiclesMakeByIdAsync(int id);
        Task<bool> AddNewVehicleMakeAsync(Model.VehicleMake vehicleMakeModel);
        Task<bool> UpdateVehicleMakeNameAsync(Model.VehicleMake vehicleMakeModel);
        Task<bool> DeleteVehicleMakeByIdAsync(int id);
    }
}
