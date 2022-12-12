using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Repository.Common;
using System.Data.Entity;
using Vehicles.Dal;
using Vehicles.Common;

namespace Vehicles.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private VehicleContext db = new VehicleContext();
        public async Task<List<Model.VehicleModel>> ReadAllVehicleModelsAsync()
        {
            return await db.VehicleModels.ToListAsync();
        }

        public async Task<List<Model.VehicleModel>> FindAsync(string sortOrder, int pageNumber, string searchString)
        {
            var vehicleModels = from vm in db.VehicleModels
                               select vm;
            if (searchString != null && searchString != "")
            {
                vehicleModels = vehicleModels.Where(vm => vm.Name.ToLower().Contains(searchString.ToLower()));
            }

            if (sortOrder != null && sortOrder.ToLower() == "desc")
                vehicleModels = vehicleModels.OrderByDescending(vm => vm.Name);
            else
                vehicleModels = vehicleModels.OrderBy(vm => vm.Name);

            Pager<Model.VehicleModel> pager = new Pager<Model.VehicleModel>();
            return await pager.CreatePaginatedListAsync(vehicleModels.AsNoTracking(), pageNumber);
        }

        public async Task<Model.VehicleModel> ReadVehiclesModelByIdAsync(int id)
        {
            Model.VehicleModel vehicleModelModel = await db.VehicleModels.FindAsync(id);

            if (vehicleModelModel == null)
            {
                return null;
            }
            return vehicleModelModel;
        }

        public async Task<List<Model.VehicleModel>> ReadVehicleModelsByLetterAsync(string letter)
        {
            return await db.VehicleModels.Where(vm => vm.Name.Substring(0, letter.Length).ToUpper() == letter.ToUpper()).ToListAsync();
        }

        public async Task<List<Model.VehicleModel>> ReadVehicleModelByVehicleMakeNameAsync(string name)
        {
            var MakeId = from vm in db.VehicleMakes
                         where vm.Name.Equals(name)
                         select vm.Id;
            var vehicleModels = await db.VehicleModels.Where(vm => vm.MakeId == MakeId.FirstOrDefault()).ToListAsync();

            return vehicleModels;
        }

        public async Task<bool> AddNewVehicleModelAsync(Model.VehicleModel vehicleModelModel)
        {
            db.VehicleModels.Add(vehicleModelModel);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateVehicleModelNameAsync(Model.VehicleModel vehicleModelModel)
        {
            var updatedVehicleModelModel = await db.VehicleModels.FindAsync(vehicleModelModel.Id);
            if (updatedVehicleModelModel == null)
            {
                return false;
            }
            updatedVehicleModelModel.Name = vehicleModelModel.Name;
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteVehicleModelByIdAsync(int id)
        {
            var vehicleModelModel = await db.VehicleModels.FindAsync(id);
            if (vehicleModelModel == null)
                return false;
            db.Entry(vehicleModelModel).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return true;
        }
    }
}
