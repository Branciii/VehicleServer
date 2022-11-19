using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<List<GenreModel>> GetGenresAsync();
    }
}
