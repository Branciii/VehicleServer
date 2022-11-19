using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Vehicles.WebAPI.Models
{
    public class VehicleModel
    {
        public int Id { get; set; } //PK
        public string Name { get; set; }
        public int MakeId { get; set; } //FK
        //public virtual VehicleMake VehicleMake { get; set; }
    }
}