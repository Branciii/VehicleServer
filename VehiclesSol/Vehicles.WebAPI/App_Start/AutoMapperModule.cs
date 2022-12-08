using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vehicles.WebAPI.Models;
using Vehicles.Model;

namespace Vehicles.WebAPI.App_Start
{
    public class AutoMapperModule //: Ninject.Modules.NinjectModule
    {
        /*public override void Load()
        {
            Bind<IMapper>().ToMethod(AutoMapper).InSingletonScope();
        }

        private IMapper AutoMapper(Ninject.Activation.IContext context)
        {
            Mapper.Initialize(config =>
            {
                config.ConstructServicesUsing(type => context.Kernel.Get(type));

                config.CreateMap<MySource, MyDest>();
                // .... other mappings, Profiles, etc.              

            });

            Mapper.AssertConfigurationIsValid(); // optional
            return Mapper.Instance;
        }*/

    }
}