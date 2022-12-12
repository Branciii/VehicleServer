using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vehicles.WebAPI.Models;

namespace Vehicles.WebAPI.App_Start
{
    public class AutomapperProfile : Profile
    {
          public AutomapperProfile()
        {
            CreateMap<VehicleMake, Model.VehicleMake>();
            CreateMap<VehicleModel, Model.VehicleModel>();
        }
    }
}