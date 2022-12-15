﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Repository.Common;
using Vehicles.Dal;
using System.Data.Entity;
using Vehicles.Common;

namespace Vehicles.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private VehicleContext db = new VehicleContext();
        public async Task<List<Model.VehicleMake>> FindAsync(string sortOrder, string sortingAttr, int pageNumber, string searchString)
        {
            var vehicleMakes = from vm in db.VehicleMakes
                           select vm;

            if (searchString != null && searchString != "")
            {
                vehicleMakes = vehicleMakes.Where(vm => vm.Name.ToLower().Contains(searchString.ToLower()));
            }

            if (sortingAttr == null)
                sortingAttr = "Name";
            else
                sortingAttr = char.ToUpper(sortingAttr.First()) + sortingAttr.Substring(1).ToLower();

            Sorter<Model.VehicleMake> sorter = new Sorter<Model.VehicleMake>();
            vehicleMakes = sorter.CreatePaginatedListAsync(vehicleMakes, sortOrder, sortingAttr);

            Pager<Model.VehicleMake> pager = new Pager<Model.VehicleMake>();
            return await pager.CreatePaginatedListAsync(vehicleMakes.AsNoTracking(), pageNumber);
        }

        public async Task<bool> AddNewVehicleMakeAsync(Model.VehicleMake vehicleMakeModel)
        {
            db.VehicleMakes.Add(vehicleMakeModel);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateVehicleMakeNameAsync(Model.VehicleMake vehicleMakeModel)
        {
            var updatedVehicleMakeModel = await db.VehicleMakes.FindAsync(vehicleMakeModel.Id);
            if (updatedVehicleMakeModel == null)
            {
                return false;
            }
            updatedVehicleMakeModel.Name = vehicleMakeModel.Name;
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteVehicleMakeByIdAsync(int id)
        {
            var vehicleMakeModel = await db.VehicleMakes.FindAsync(id);
            if (vehicleMakeModel == null)
                return false;
            db.Entry(vehicleMakeModel).State = EntityState.Deleted;

            // delete models referencing the vehicle make that's being deleted
            var vehicleModels = from vm in db.VehicleModels
                                where vm.MakeId.Equals(id)
                                select vm;
            foreach (Model.VehicleModel vm in vehicleModels)
            {
                db.Entry(vm).State = EntityState.Deleted;
            }

            await db.SaveChangesAsync();
            return true;
        }
    }
}

