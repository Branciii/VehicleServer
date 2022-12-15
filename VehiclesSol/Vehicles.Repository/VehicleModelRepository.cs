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

        private IGenericRepository<Model.VehicleModel> GenericRepository { get; set; }

        public VehicleModelRepository(IGenericRepository<Model.VehicleModel> genericRepository)
        {
            this.GenericRepository = genericRepository;
        }
        public async Task<List<Model.VehicleModel>> FindAsync(string sortOrder, string sortingAttr, int pageNumber, string searchString, string searchAttr)
        {
            var vehicleModels = from vm in db.VehicleModels
                               select vm;

            return await this.GenericRepository.FindAsync(vehicleModels, sortOrder, sortingAttr, pageNumber, searchString, searchAttr);
        }

        public async Task<bool> AddNewVehicleModelAsync(Model.VehicleModel vehicleModel)
        {
            db.VehicleModels.Add(vehicleModel);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateVehicleModelNameAsync(Model.VehicleModel vehicleModel)
        {
            var updatedVehicleModel = await db.VehicleModels.FindAsync(vehicleModel.Id);
            if (updatedVehicleModel == null)
            {
                return false;
            }
            updatedVehicleModel.Name = vehicleModel.Name;
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteVehicleModelByIdAsync(int id)
        {
            var vehicleModel = await db.VehicleModels.FindAsync(id);
            return await this.GenericRepository.DeleteVehicleAsync(db, vehicleModel);
        }
    }
}
