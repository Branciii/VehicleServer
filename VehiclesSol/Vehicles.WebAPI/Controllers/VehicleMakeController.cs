using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vehicles.WebAPI.Models;
using Vehicles.Service.Common;
using Vehicles.Model;

namespace Vehicles.WebAPI.Controllers
{

    public class VehicleMakeController : ApiController
    {
        private IVehicleMakeService VehicleService { get; set; }
        private IMapper Mapper { get; set; }

        public VehicleMakeController(IVehicleMakeService vehicleService)
        {
            this.VehicleService = vehicleService;
        }

        [HttpGet]
        [Route("api/readAllVehicleMakes")]
        public HttpResponseMessage ReadAllVehicleMakes()
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.VehicleService.ReadAllVehicleMakes());
        }

        [HttpGet]
        [Route("api/readVehiclesMakeById/{id}")]
        public HttpResponseMessage ReadVehiclesMakeById(int id)
        {
            var vehicleMakeModel = this.VehicleService.ReadVehiclesMakeById(id);
            if (vehicleMakeModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, vehicleMakeModel);
        }

        [HttpPost]
        [Route("api/addNewVehicleMake")]
        public HttpResponseMessage AddNewVehicleMake([FromBody] VehicleMake vehicleMake)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleMake, VehicleMakeModel>(); });
            this.Mapper = config.CreateMapper();
            VehicleMakeModel vehicleMakeModel = this.Mapper.Map<VehicleMake, VehicleMakeModel>(vehicleMake);

            this.VehicleService.AddNewVehicleMake(vehicleMakeModel);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/updateVehicleMakeName")]
        public HttpResponseMessage UpdateVehicleMakeName([FromBody] VehicleMakeModel vehicleMakeModel)
        {
            VehicleMakeModel updatedVehicleMakeModel = this.VehicleService.UpdateVehicleMakeName(vehicleMakeModel);
            if (updatedVehicleMakeModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpDelete]
        [Route("api/deleteVehicleMakeById/{id}")]
        public HttpResponseMessage DeleteVehicleMakeById(int id)
        {
            this.VehicleService.DeleteVehicleMakeById(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
