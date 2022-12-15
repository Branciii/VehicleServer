using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Common
{
    public interface ISorter<T>
    {
        IOrderedQueryable<T> CreateSortedList(IQueryable<T> vehicles, string sortOrder, string sortingAttr);
    }
}
