using Vehicles.WebAPI.Models;
using Vehicles.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Vehicles.WebAPI.DAL
{
    public class VehicleContext : DbContext
    {
        public VehicleContext() : base("VehicleContext")
        {
        }
        public DbSet<VehicleMakeModel> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}