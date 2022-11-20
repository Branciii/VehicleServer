using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vehicles.WebAPI.Models;
using Vehicles.Service.Common;
using Vehicles.Model;
using AutoMapper;

namespace Vehicles.WebAPI.Controllers
{
    public class VehicleModelController : ApiController
    {
        private IVehicleModelService VehicleService { get; set; }
        private IMapper Mapper { get; set; }

        public VehicleModelController(IVehicleModelService vehicleService)
        {
            this.VehicleService = vehicleService;
        }

        [HttpGet]
        [Route("api/readAllVehicleModels")]
        public HttpResponseMessage ReadAllVehicleModels()
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.VehicleService.ReadAllVehicleMakes());
        }

        
        [HttpGet]
        [Route("api/readVehicleModelById/{id}")]
        public HttpResponseMessage ReadVehicleModelById(int id)
        {
            var vehicleModelModel = this.VehicleService.ReadVehiclesModelById(id);
            if (vehicleModelModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, vehicleModelModel);
        }

        
        [HttpPost]
        [Route("api/addNewVehicleModel")]
        public HttpResponseMessage AddNewVehicleModel([FromBody] VehicleModel vehicleModel)
        {
            if ((vehicleModel.Name == null))
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleModel, VehicleModelModel>(); });
            this.Mapper = config.CreateMapper();
            VehicleModelModel vehicleModelModel = this.Mapper.Map<VehicleModel, VehicleModelModel>(vehicleModel);

            this.VehicleService.AddNewVehicleModel(vehicleModelModel);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/updateVehicleModelName")]
        public HttpResponseMessage UpdateVehicleModelName([FromBody] VehicleModelModel vehicleModelModel)
        {
            var updatedVehicleModelModel = this.VehicleService.UpdateVehicleModelName(vehicleModelModel);
            if (updatedVehicleModelModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        
        [HttpDelete]
        [Route("api/deleteVehicleModelById/{id}")]
        public HttpResponseMessage DeleteVehicleModelById(int id)
        {
            this.VehicleService.DeleteVehicleModelById(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
