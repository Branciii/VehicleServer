using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Vehicles.WebAPI.Models;
using Vehicles.Model;
using Vehicles.Dal;

namespace Vehicles.WebAPI.DAL
{
    public class VehicleInitializer : DropCreateDatabaseAlways<VehicleContext>
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

            var vehicleModels = new List<VehicleModelModel>
            {
            new VehicleModelModel{MakeId=1,Name="T-Cross"},
            new VehicleModelModel{MakeId=1,Name="Polo"},
            new VehicleModelModel{MakeId=2,Name="X5"},
            new VehicleModelModel{MakeId=2,Name="X6"},
            new VehicleModelModel{MakeId=3,Name="C3"},
            new VehicleModelModel{MakeId=3,Name="C4"},
            new VehicleModelModel{MakeId=4,Name="Yaris"},
            new VehicleModelModel{MakeId=4,Name="Auris"},
            new VehicleModelModel{MakeId=5,Name="Punto"},
            new VehicleModelModel{MakeId=5,Name="Panda"}
            };
            vehicleModels.ForEach(s => context.VehicleModels.Add(s));
            context.SaveChanges();
           
        }
    }
}