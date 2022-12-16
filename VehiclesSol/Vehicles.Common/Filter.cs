using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Vehicles.Common
{
    public class Filter
    {
        public string SearchString { get; set; }
        public string SearchAttr { get; set; }
    }
}
