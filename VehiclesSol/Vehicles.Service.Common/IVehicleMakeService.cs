﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Vehicles.Model;

namespace Vehicles.Service.Common
{
    public interface IVehicleMakeService
    {
        DbSet<VehicleMakeModel> ReadAllVehicleMakes();
        Task<VehicleMakeModel> ReadVehiclesMakeByIdAsync(int id);
        Task<bool> AddNewVehicleMakeAsync(VehicleMakeModel vehicleMakeModel);
        Task<bool> UpdateVehicleMakeNameAsync(VehicleMakeModel vehicleMakeModel);
        Task<bool> DeleteVehicleMakeByIdAsync(int id);

    }
}
