﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vehicles.WebAPI.Models
{
    public class SearchParams
    {
        public string SortOrder { get; set; }
        public string SearchString { get; set; }
        public int PageNumber { get; set; } = 1;
    }
}