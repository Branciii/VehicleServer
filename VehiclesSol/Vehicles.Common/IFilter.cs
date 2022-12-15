using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Common
{
    public interface IFilter<T>
    {
        IQueryable<T> CreateFilteredList(IQueryable<T> vehicles, string searchString, string searchAttr);
    }
}
