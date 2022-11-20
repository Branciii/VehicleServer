using Vehicles.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Vehicles.Dal
{
    public class VehicleContext : DbContext
    {
        public VehicleContext() : base("VehicleContext")
        {
        }
        public DbSet<VehicleMakeModel> VehicleMakes { get; set; }
        public DbSet<VehicleModelModel> VehicleModels { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
