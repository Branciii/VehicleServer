using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vehicles.WebAPI.Models;
using Vehicles.Service.Common;
using AutoMapper;
using System.Threading.Tasks;

namespace Vehicles.WebAPI.Controllers
{
    public class VehicleModelController : ApiController
    {
        private IVehicleModelService VehicleService { get; set; }
        private IMapper Mapper { get; set; }

        public VehicleModelController(IVehicleModelService vehicleService, IMapper mapper)
        {
            this.VehicleService = vehicleService;
            this.Mapper = mapper;
        }

        [HttpGet]
        [Route("api/searchVehicleModels")]
        public async Task<HttpResponseMessage> FindAsync([FromBody] SearchParams searchParams)
        {
            var vehicleModels = await this.VehicleService.FindAsync(searchParams.Filter, searchParams.Sorter, searchParams.Pager);
            if (!vehicleModels.Any()) //empty
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, vehicleModels);
            }
        }

        [HttpPost]
        [Route("api/addNewVehicleModel")]
        public async Task<HttpResponseMessage> AddNewVehicleModelAsync([FromBody] VehicleModel vehicleModel)
        {
            if (vehicleModel.Name == null && vehicleModel.MakeId != 0)
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed);

            Model.VehicleModel vehicleModelWithId = this.Mapper.Map<VehicleModel, Model.VehicleModel>(vehicleModel);

            await this.VehicleService.AddNewVehicleModelAsync(vehicleModelWithId);

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        [Route("api/updateVehicleModelName")]
        public async Task<HttpResponseMessage> UpdateVehicleModelNameAsync([FromBody] Model.VehicleModel vehicleModel)
        {
            if(await this.VehicleService.UpdateVehicleModelNameAsync(vehicleModel))
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
