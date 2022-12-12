using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Vehicles.Dal
{
    public class VehicleInitializer : DropCreateDatabaseAlways<VehicleContext>
    {
        protected override void Seed(VehicleContext context)
        {
            var vehicleMakes = new List<Model.VehicleMake>
            {
            new Model.VehicleMake{ Name="Volkswagen"},
            new Model.VehicleMake{ Name="BMW"},
            new Model.VehicleMake{ Name="Citroen"},
            new Model.VehicleMake{ Name="Toyota"},
            new Model.VehicleMake{ Name="Fiat"}
            };

            vehicleMakes.ForEach(s => context.VehicleMakes.Add(s));
            context.SaveChanges();

            var vehicleModels = new List<Model.VehicleModel>
            {
            new Model.VehicleModel{ MakeId=1, Name="T-Cross"},
            new Model.VehicleModel{ MakeId=1, Name="Polo"},
            new Model.VehicleModel{ MakeId=2, Name="X5"},
            new Model.VehicleModel{ MakeId=2, Name="X6"},
            new Model.VehicleModel{ MakeId=3, Name="C3"},
            new Model.VehicleModel{ MakeId=3, Name="C4"},
            new Model.VehicleModel{ MakeId=4, Name="Yaris"},
            new Model.VehicleModel{ MakeId=4, Name="Auris"},
            new Model.VehicleModel{ MakeId=5, Name="Punto"},
            new Model.VehicleModel{ MakeId=5, Name="Panda"}
            };
            vehicleModels.ForEach(s => context.VehicleModels.Add(s));
            context.SaveChanges();

        }
    }
}
