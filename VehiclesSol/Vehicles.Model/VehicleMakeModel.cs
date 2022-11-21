using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Model.Common;

namespace Vehicles.Model
{
    public class VehicleMakeModel : IVehicleMakeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
