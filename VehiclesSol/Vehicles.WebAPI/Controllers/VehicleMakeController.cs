using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vehicles.WebAPI.Models;
using Vehicles.Service.Common;
using System.Threading.Tasks;

namespace Vehicles.WebAPI.Controllers
{
    public class VehicleMakeController : ApiController
    {
        private IVehicleMakeService VehicleService { get; set; }
        private IMapper Mapper { get; set; }

        public VehicleMakeController(IVehicleMakeService vehicleService, IMapper mapper)
        {
            this.VehicleService = vehicleService;
            this.Mapper = mapper;
        }

        [HttpGet]
        [Route("api/searchVehicleMakes")]
        public async Task<HttpResponseMessage> FindAsync([FromBody] SearchParams searchParams)
        {
            var vehicleMakes = await this.VehicleService.FindAsync(searchParams.SortOrder, searchParams.SortingAttr, searchParams.PageNumber, searchParams.SearchString, searchParams.SearchAttr);
            if (!vehicleMakes.Any()) //empty
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, vehicleMakes);
            }
        }

        [HttpPost]
        [Route("api/addNewVehicleMake")]
        public async Task<HttpResponseMessage> AddNewVehicleMakeAsync([FromBody] VehicleMake vehicleMake)
        {
            if (vehicleMake.Name == null)
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed);

            Model.VehicleMake vehicleMakeWithId = this.Mapper.Map<VehicleMake, Model.VehicleMake>(vehicleMake);

            await this.VehicleService.AddNewVehicleMakeAsync(vehicleMakeWithId);

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        [Route("api/updateVehicleMakeName")]
        public async Task<HttpResponseMessage> UpdateVehicleMakeNameAsync([FromBody] Model.VehicleMake vehicleMake)
        {
            if (await this.VehicleService.UpdateVehicleMakeNameAsync(vehicleMake))
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateResponse(HttpStatusCode.NotFound); 
        }


        [HttpDelete]
        [Route("api/deleteVehicleMakeById/{id}")]
        public async Task<HttpResponseMessage> DeleteVehicleMakeByIdAsync(int id)
        {
            if (await this.VehicleService.DeleteVehicleMakeByIdAsync(id))
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
