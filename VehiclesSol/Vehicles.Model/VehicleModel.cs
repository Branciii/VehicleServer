using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Model.Common;

namespace Vehicles.Model
{
    public class VehicleModel : IVehicleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MakeId { get; set; }
        //public virtual VehicleMake VehicleMake { get; set; }
        public string Abrv { get; set; }
    }
}
