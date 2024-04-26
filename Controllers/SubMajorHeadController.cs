using IFMS_Master_Backend.BAL.IServices;
using IFMS_Master_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IFMS_Master_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubMajorHeadController : ControllerBase
    {
        private readonly ISubMajorHeadService _subMajorHeadService;
        public SubMajorHeadController(ISubMajorHeadService subMajorheadService)
        {
            _subMajorHeadService = subMajorheadService;
        }
        [HttpGet]
        public async Task<ServiceResponse<ICollection<SubMajorHeadModel>>> Get()
        {
            ServiceResponse<ICollection<SubMajorHeadModel>> serviceResponse = new ServiceResponse<ICollection<SubMajorHeadModel>>();
            try
            {
                serviceResponse.result = await _subMajorHeadService.getAllSubHead();
                serviceResponse.statusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                serviceResponse.statusCode = HttpStatusCode.BadRequest;
                serviceResponse.errorMessage = "Error";
            }
            return serviceResponse;


        }


        [HttpGet("SubMajorHeadById/{Id}")]
        public async Task<ServiceResponse<SubMajorHeadModel>> getById(int Id)
        {
            ServiceResponse<SubMajorHeadModel> response = new ServiceResponse<SubMajorHeadModel>();
            try
            {
                response.result = await _subMajorHeadService.getSubHeadById(Id);
                response.statusCode = HttpStatusCode.Found;

            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.NotFound;
                response.errorMessage = "Error";
            }
            return response;
        }
        [HttpPost("SubMajorHeadAdd")]

        public async Task<ServiceResponse<SubMajorHeadModel>> addSubHead(SubMajorHeadModel subHeaddata)
        {
            ServiceResponse<SubMajorHeadModel> response = new ServiceResponse<SubMajorHeadModel>();
            try
            {
                response.result = await _subMajorHeadService.CreateSubHead(subHeaddata);
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

        [HttpDelete("SubMajorHeadDelete/{Id}")]
        public async Task<ServiceResponse<bool>> DeleteSubHead(int Id)
        {
            ServiceResponse<bool> serviceResp = new ServiceResponse<bool>();

            try
            {
                serviceResp.result = await _subMajorHeadService.DeleteSubHead(Id);
                serviceResp.statusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                serviceResp.statusCode = HttpStatusCode.BadRequest;
                serviceResp.errorMessage = "Error";
            }
            return serviceResp;
        }

        [HttpPut("SubMajorHeadUpdate/{Id}")]
        public async Task<ServiceResponse<bool>> UpdateSubHead(int Id, SubMajorHeadModel subHeaddata)
        {
            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();
            try
            {
                serviceResponse.result = await _subMajorHeadService.UpdateSubHead(Id, subHeaddata);
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
