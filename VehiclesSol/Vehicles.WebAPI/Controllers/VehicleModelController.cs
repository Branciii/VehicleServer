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
using System.Threading.Tasks;

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
        [Route("api/searchVehicleModels")]
        public async Task<HttpResponseMessage> FindAsync([FromBody] SearchParams searchParams)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await this.VehicleService.FindAsync(searchParams.SortOrder, searchParams.PageNumber, searchParams.SearchString));
        }

        [HttpGet]
        [Route("api/readAllVehicleModels")]
        public HttpResponseMessage ReadAllVehicleModels()
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.VehicleService.ReadAllVehicleModels());
        }

        [HttpGet]
        [Route("api/readSortedVehicleModels/{sortOrder}")]
        public async Task<HttpResponseMessage> ReadSortedVehicleModelsAsync(string sortOrder)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await this.VehicleService.ReadSortedVehicleModelsAsync(sortOrder));
        }

        [HttpGet]
        [Route("api/readVehicleModelsByPage/{pageNumber}")]
        public async Task<HttpResponseMessage> ReadVehicleModelsByPageAsync(int pageNumber)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await this.VehicleService.ReadVehicleModelsByPageAsync(pageNumber));
        }

        [HttpGet]
        [Route("api/readVehicleModelsByLetter/{letter}")]
        public async Task<HttpResponseMessage> ReadVehicleModelsByLetterAsync(string letter)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await this.VehicleService.ReadVehicleModelsByLetterAsync(letter));
        }


        [HttpGet]
        [Route("api/readVehicleModelById/{id}")]
        public async Task<HttpResponseMessage> ReadVehiclesModelByIdAsync(int id)
        {
            var vehicleModelModel = await this.VehicleService.ReadVehiclesModelByIdAsync(id);
            if (vehicleModelModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, vehicleModelModel);
        }

        [HttpGet]
        [Route("api/readVehicleModelByVehicleMakeName/{name}")]
        public async Task<HttpResponseMessage> ReadVehicleModelByVehicleMakeNameAsync(string name)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await this.VehicleService.ReadVehicleModelByVehicleMakeNameAsync(name));
        }

        [HttpPost]
        [Route("api/addNewVehicleModel")]
        public async Task<HttpResponseMessage> AddNewVehicleModelAsync([FromBody] VehicleModel vehicleModel)
        {
            if (vehicleModel.Name == null)
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed);

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleModel, VehicleModelModel>(); });
            this.Mapper = config.CreateMapper();
            VehicleModelModel vehicleModelModel = this.Mapper.Map<VehicleModel, VehicleModelModel>(vehicleModel);

            await this.VehicleService.AddNewVehicleModelAsync(vehicleModelModel);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/updateVehicleModelName")]
        public async Task<HttpResponseMessage> UpdateVehicleModelNameAsync([FromBody] VehicleModelModel vehicleModelModel)
        {
            if(await this.VehicleService.UpdateVehicleModelNameAsync(vehicleModelModel))
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateResponse(HttpStatusCode.NotFound);


        }
        
        [HttpDelete]
        [Route("api/deleteVehicleModelById/{id}")]
        public async Task<HttpResponseMessage> DeleteVehicleModelByIdAsync(int id)
        {
            if (await this.VehicleService.DeleteVehicleModelByIdAsync(id))
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateResponse(HttpStatusCode.NotFound);
            
        }

    }
}
