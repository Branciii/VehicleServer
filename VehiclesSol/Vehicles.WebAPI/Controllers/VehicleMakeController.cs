using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;
using Vehicles.WebAPI.DAL;
using Vehicles.WebAPI.Models;
using Vehicles.Service.Common;
using Vehicles.Model;

namespace Vehicles.WebAPI.Controllers
{

    public class VehicleMakeController : ApiController
    {

        private VehicleContext db = new VehicleContext();
        private IVehicleMakeService VehicleService { get; set; }
        private IMapper Mapper { get; set; }

        public VehicleMakeController(IVehicleMakeService vehicleService, IMapper mapper)
        {
            this.VehicleService = vehicleService;
            this.Mapper = mapper;
        }

        [HttpGet]
        [Route("api/readAllVehicleMakes")]
        public HttpResponseMessage ReadAllVehicleMakes()
        {
            return Request.CreateResponse(HttpStatusCode.OK, db.VehicleMakes);
        }

        [HttpGet]
        [Route("api/readVehiclesMakeById/{id}")]
        public HttpResponseMessage ReadVehiclesMakeById(int id)
        {
            VehicleMakeModel vehicleMakeModel = db.VehicleMakes.Find(id);

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
            IMapper iMapper = config.CreateMapper();
            VehicleMakeModel vehicleMakeModel = iMapper.Map<VehicleMake, VehicleMakeModel>(vehicleMake);
            db.VehicleMakes.Add(vehicleMakeModel);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/updateVehicleMakeName")]
        public HttpResponseMessage UpdateVehicleMakeName([FromBody] VehicleMake vehicleMake)
        {
            VehicleMakeModel updatedVehicleMakeModel = db.VehicleMakes.Find(vehicleMake.Id);
            if (updatedVehicleMakeModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            updatedVehicleMakeModel.Name = vehicleMake.Name;
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpDelete]
        [Route("api/deleteVehicleMakeById/{id}")]
        public HttpResponseMessage DeleteVehicleMakeById(int id)
        {
            VehicleMakeModel vehicleMakeModel = db.VehicleMakes.Find(id);
            db.Entry(vehicleMakeModel).State = EntityState.Deleted;

            // delete models referencing the vehicle make that's being deleted
            var vehicleModels = from vm in db.VehicleModels
                                where vm.MakeId.Equals(id)
                                select vm;
            foreach (VehicleModel vm in vehicleModels)
            {
                db.Entry(vm).State = EntityState.Deleted;
            }

            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
