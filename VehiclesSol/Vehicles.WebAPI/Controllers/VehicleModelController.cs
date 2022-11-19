using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Vehicles.WebAPI.DAL;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Vehicles.WebAPI.Models;

namespace Vehicles.WebAPI.Controllers
{
    public class VehicleModelController : ApiController
    {
        private VehicleContext db = new VehicleContext();

        [HttpGet]
        [Route("api/readAllVehicleModels")]
        public HttpResponseMessage ReadAllVehicleModels()
        {
            return Request.CreateResponse(HttpStatusCode.OK, db.VehicleModels);
        }

        [HttpGet]
        [Route("api/readVehicleModelById/{id}")]
        public HttpResponseMessage ReadVehicleModelById(int id)
        {
            VehicleModel vehicleModel = db.VehicleModels.Find(id);
            if (vehicleModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, vehicleModel) ;
        }

        [HttpPost]
        [Route("api/addNewVehicleModel")]
        public HttpResponseMessage AddNewVehicleModel([FromBody] VehicleModel vehicleModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            using (db)
            {
                db.VehicleModels.Add(new VehicleModel()
                {
                    Name = vehicleModel.Name,
                    MakeId = vehicleModel.MakeId
                });

                db.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpDelete]
        [Route("api/deleteVehicleModelById/{id}")]
        public HttpResponseMessage DeleteVehicleModelById(int id)
        {
            VehicleModel vehicleModel = db.VehicleModels.Find(id);
            db.Entry(vehicleModel).State = EntityState.Deleted;
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
