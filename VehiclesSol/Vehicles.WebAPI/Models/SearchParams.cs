using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vehicles.Model;
using Vehicles.Common;

namespace Vehicles.WebAPI.Models
{
    public class SearchParams
    {
        public Filter Filter { get; set; }
        public Sorter Sorter { get; set; }
        public Pager Pager { get; set; }

    }
}