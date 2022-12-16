using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vehicles.Model;

namespace Vehicles.WebAPI.Models
{
    public class SearchParams
    {
        public string SortOrder { get; set; }
        public string SortingAttr { get; set; }
        public string SearchString { get; set; }
        public string SearchAttr { get; set; }
        //public FilterParams FilterParams { get; set; }
        public int PageNumber { get; set; } = 1;
    }
}