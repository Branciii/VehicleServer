using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Repository.Common;
using Vehicles.Dal;
using System.Data.Entity;

namespace Vehicles.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private VehicleContext db = new VehicleContext();
        private IGenericRepository<Model.VehicleMake> GenericRepository { get; set; }

        public VehicleMakeRepository(IGenericRepository<Model.VehicleMake> genericRepository)
        {
            this.GenericRepository = genericRepository;
        }

        public async Task<List<Model.VehicleMake>> FindAsync(string sortOrder, string sortingAttr, int pageNumber, string searchString, string searchAttr)
        {
            var vehicleMakes = from vm in db.VehicleMakes
                           select vm;

            return await this.GenericRepository.FindAsync(vehicleMakes, sortOrder, sortingAttr, pageNumber, searchString, searchAttr);
        }

        public async Task<bool> AddNewVehicleMakeAsync(Model.VehicleMake vehicleMake)
        {
            db.VehicleMakes.Add(vehicleMake);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateVehicleMakeNameAsync(Model.VehicleMake vehicleMake)
        {
            var updatedVehicleMake = await db.VehicleMakes.FindAsync(vehicleMake.Id);
            if (updatedVehicleMake == null)
            {
                return false;
            }
            updatedVehicleMake.Name = vehicleMake.Name;
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteVehicleMakeByIdAsync(int id)
        {
            var vehicleMake = await db.VehicleMakes.FindAsync(id);
            await this.GenericRepository.DeleteVehicleAsync(db, vehicleMake);

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

