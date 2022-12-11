using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Common
{
    public class Pager<T>
    {
        public async Task<List<T>> CreatePaginatedListAsync(IQueryable<T> vehicles, int pageNumber)
        {
            return await vehicles.Skip((pageNumber - 1) * 3).Take(3).ToListAsync();
        }
    }
}
