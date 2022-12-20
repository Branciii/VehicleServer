namespace Vehicles.Dal.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Vehicles.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<Vehicles.Dal.VehicleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Vehicles.Dal.VehicleContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var vehicleMakes = new List<Model.VehicleMake>
            {
            new Model.VehicleMake{ Name="Volkswagen", Abrv="aVW"},
            new Model.VehicleMake{ Name="BMW", Abrv="Z"},
            new Model.VehicleMake{ Name="Citroen"},
            new Model.VehicleMake{ Name="Toyota", Abrv="Tyt"},
            new Model.VehicleMake{ Name="Fiat", Abrv="ft"}
            };

            vehicleMakes.ForEach(s => context.VehicleMakes.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var vehicleModels = new List<Model.VehicleModel>
            {
            new Model.VehicleModel{ MakeId=1, Name="T-Cross", Abrv="TCross"},
            new Model.VehicleModel{ MakeId=1, Name="Polo", Abrv="pl"},
            new Model.VehicleModel{ MakeId=2, Name="X5"},
            new Model.VehicleModel{ MakeId=2, Name="X6"},
            new Model.VehicleModel{ MakeId=3, Name="C3"},
            new Model.VehicleModel{ MakeId=3, Name="C4"},
            new Model.VehicleModel{ MakeId=4, Name="Yaris", Abrv="yrs"},
            new Model.VehicleModel{ MakeId=4, Name="Auris", Abrv="aris"},
            new Model.VehicleModel{ MakeId=5, Name="Punto", Abrv="pnt"},
            new Model.VehicleModel{ MakeId=5, Name="Panda", Abrv="pnd"}
            };

            vehicleModels.ForEach(s => context.VehicleModels.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
        }
    }
}
