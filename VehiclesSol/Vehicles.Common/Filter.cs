using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Vehicles.Common
{
    public class Filter<T>
    {
        public async Task<List<T>> CreateFilteredListAsync(IQueryable<T> vehicles, int pageNumber)
        {
            return await vehicles.Skip((pageNumber - 1) * 3).Take(3).ToListAsync();
        }
    }
}
