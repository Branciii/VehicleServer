﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vehicles.WebAPI.Models;
using Vehicles.Service.Common;
using Vehicles.Model;
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
            var vehicleMakes = await this.VehicleService.FindAsync(searchParams.SortOrder, searchParams.PageNumber, searchParams.SearchString);
            if (!vehicleMakes.Any()) //empty
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, vehicleMakes);
            }
        }

        [HttpGet]
        [Route("api/readAllVehicleMakes")]
        public HttpResponseMessage ReadAllVehicleMakes()
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.VehicleService.ReadAllVehicleMakes());
        }

        [HttpGet]
        [Route("api/readVehicleMakesByLetter/{letter}")]
        public async Task<HttpResponseMessage> ReadVehicleMakesByLetterAsync(string letter)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await this.VehicleService.ReadVehicleMakesByLetterAsync(letter));
        }

        [HttpGet]
        [Route("api/readVehicleMakeById/{id}")]
        public async Task<HttpResponseMessage> ReadVehiclesMakeByIdAsync(int id)
        {
            var vehicleMakeModel = await this.VehicleService.ReadVehiclesMakeByIdAsync(id);
            if (vehicleMakeModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, vehicleMakeModel);
        }

        [HttpPost]
        [Route("api/addNewVehicleMake")]
        public async Task<HttpResponseMessage> AddNewVehicleMakeAsync([FromBody] VehicleMake vehicleMake)
        {
            if (vehicleMake.Name == null)
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed);

            VehicleMakeModel vehicleMakeModel = this.Mapper.Map<VehicleMake, VehicleMakeModel>(vehicleMake);

            await this.VehicleService.AddNewVehicleMakeAsync(vehicleMakeModel);

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        [Route("api/updateVehicleMakeName")]
        public async Task<HttpResponseMessage> UpdateVehicleMakeNameAsync([FromBody] VehicleMakeModel vehicleMakeModel)
        {
            if (await this.VehicleService.UpdateVehicleMakeNameAsync(vehicleMakeModel))
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
