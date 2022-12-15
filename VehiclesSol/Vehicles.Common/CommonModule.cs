using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Common
{
    class CommonModule<T> : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IFilter<T>>().To<Filter<T>>();
            Bind<ISorter<T>>().To<Sorter<T>>();
            Bind<IPager<T>>().To<Pager<T>>();
        }
    }
}
