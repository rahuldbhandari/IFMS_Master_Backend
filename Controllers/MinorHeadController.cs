using IFMS_Master_Backend.BAL.Interfaces;
using IFMS_Master_Backend.DAL;
using IFMS_Master_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IFMS_Master_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MinorHeadController : ControllerBase
    {
        private readonly IMinorHeadService _minorHeadService;
        public MinorHeadController(IMinorHeadService minorheadService)
        {
            _minorHeadService = minorheadService;
        }
        [HttpGet]
        public async Task<ServiceResponse<ICollection<MinorHeadModel>>> Get()
        {
            ServiceResponse<ICollection<MinorHeadModel>> serviceResponse = new ServiceResponse<ICollection<MinorHeadModel>>();
            try
            {
                serviceResponse.result = await _minorHeadService.getAllMinorHead();
                serviceResponse.statusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                serviceResponse.statusCode = HttpStatusCode.BadRequest;
                serviceResponse.errorMessage = "Error";
            }
            return serviceResponse;


        }

        [HttpGet("MinorHeadById/{Id}")]
        public async Task<ServiceResponse<MinorHeadModel>> getById(int Id)
        {
            ServiceResponse<MinorHeadModel> response = new ServiceResponse<MinorHeadModel>();
            try
            {
                response.result = await _minorHeadService.GetMinorHeadById(Id);
                response.statusCode = HttpStatusCode.Found;

            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.NotFound;
                response.errorMessage = "Error";
            }
            return response;
        }

        [HttpPost("MinorHeadAdd")]

        public async Task<ServiceResponse<MinorHeadModel>> addHead(MinorHeadModel minorHeaddata)
        {
            ServiceResponse<MinorHeadModel> response = new ServiceResponse<MinorHeadModel>();
            try
            {
                response.result = await _minorHeadService.CreateMinorHead(minorHeaddata);
                response.statusCode = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.errorMessage = "Error";
            }
            /*if (subHeaddata == null)
            {
                return BadRequest("payload invalid");
            }*/

            return response;
        }


        [HttpDelete("MinorHeadDelete/{Id}")]
        public async Task<ServiceResponse<bool>> DeleteMinorHead(int Id)
        {
            ServiceResponse<bool> serviceResp = new ServiceResponse<bool>();

            try
            {
                serviceResp.result = await _minorHeadService.DeleteMinorHead(Id);
                serviceResp.statusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                serviceResp.statusCode = HttpStatusCode.BadRequest;
                serviceResp.errorMessage = "Error";
            }
            return serviceResp;
        }


        [HttpPut("MinorHeadUpdate/{Id}")]
        public async Task<ServiceResponse<bool>> UpdateMinorHead(int Id, MinorHeadModel minorHeaddata)
        {
            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();
            try
            {
                serviceResponse.result = await _minorHeadService.UpdateMinorHead(Id, minorHeaddata);
                serviceResponse.statusCode = HttpStatusCode.Found;
            }
            catch (Exception ex)
            {
                serviceResponse.statusCode = HttpStatusCode.BadRequest;
                serviceResponse.errorMessage = "Error";
            }
            return serviceResponse;
        }




    }
}
