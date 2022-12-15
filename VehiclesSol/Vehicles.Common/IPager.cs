﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Model;

namespace Vehicles.Common
{
    public interface IPager<T>
    {
        Task<List<T>> CreatePaginatedListAsync(IQueryable<T> vehicles, int pageNumber);
    }
}
