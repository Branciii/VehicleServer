using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Vehicles.WebAPI.Models;
using Vehicles.Model;

namespace Vehicles.WebAPI.DAL
{
    public class VehicleInitializer : DropCreateDatabaseIfModelChanges<VehicleContext>
    {
        protected override void Seed(VehicleContext context)
        {
            var vehicleMakes = new List<VehicleMakeModel>
            {
            new VehicleMakeModel{Name="Volkswagen"},
            new VehicleMakeModel{Name="BMW"},
            new VehicleMakeModel{Name="Citroen"},
            new VehicleMakeModel{Name="Toyota"},
            new VehicleMakeModel{Name="Fiat"}
            };

            vehicleMakes.ForEach(s => context.VehicleMakes.Add(s));
            context.SaveChanges();

            var vehicleModels = new List<VehicleModel>
            {
            new VehicleModel{MakeId=1,Name="T-Cross"},
            new VehicleModel{MakeId=1,Name="Polo"},
            new VehicleModel{MakeId=2,Name="X5"},
            new VehicleModel{MakeId=2,Name="X6"},
            new VehicleModel{MakeId=3,Name="C3"},
            new VehicleModel{MakeId=3,Name="C4"},
            new VehicleModel{MakeId=4,Name="Punto"},
            new VehicleModel{MakeId=4,Name="Panda"}
            };
            vehicleModels.ForEach(s => context.VehicleModels.Add(s));
            context.SaveChanges();
           
        }
    }
}