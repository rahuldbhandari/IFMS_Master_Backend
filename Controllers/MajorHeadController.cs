using IFMS_Master_Backend.BAL.IServices;
using IFMS_Master_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IFMS_Master_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorHeadController : ControllerBase
    {
        private readonly IMajorHeadService _majorHeadService;
        public MajorHeadController(IMajorHeadService majorheadService)
        {
            _majorHeadService = majorheadService;
        }
        [HttpGet]
        public async Task<ServiceResponse<ICollection<MajorHeadModel>>> Get()
        {
            ServiceResponse<ICollection<MajorHeadModel>> serviceResponse = new ServiceResponse<ICollection<MajorHeadModel>>();
            try
            {
                serviceResponse.result = await _majorHeadService.getAllHead();
                serviceResponse.statusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                serviceResponse.statusCode = HttpStatusCode.BadRequest;
                serviceResponse.errorMessage = "Error";
            }
            return serviceResponse;


        }

        [HttpGet("MajorHeadById/{Id}")]
        public async Task<ServiceResponse<MajorHeadModel>> getById(int Id)
        {
            ServiceResponse<MajorHeadModel> response = new ServiceResponse<MajorHeadModel>();
            try
            {
                response.result = await _majorHeadService.GetHeadById(Id);
                response.statusCode = HttpStatusCode.Found;
            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.NotFound;
                response.errorMessage = "Error";
            }
            return response;

        }

        [HttpPost("MajorHeadAdd")]

        public async Task<ServiceResponse<MajorHeadModel>> addHead([FromBody] MajorHeadModel headdata)
        {
            ServiceResponse<MajorHeadModel> response = new ServiceResponse<MajorHeadModel>();
            try
            {
                response.result = await _majorHeadService.CreateHead(headdata);
                response.statusCode = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.errorMessage = "Error";
            }
            return response;

        }

        /*public async Task<IActionResult> addHead([FromBody] MajorHeadModel headdata)
        {
            
            var data = _majorHeadService.CreateHead(headdata);
            return Ok(data.Result);
        }*/

        [HttpDelete("MajorHeadDelete/{Id}")]
        public async Task<ServiceResponse<bool>> DeleteHead(int Id)
        {
            ServiceResponse<bool> serviceResp = new ServiceResponse<bool>();

            try
            {
                serviceResp.result = await _majorHeadService.DeleteHead(Id);
                serviceResp.statusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                serviceResp.statusCode = HttpStatusCode.BadRequest;
                serviceResp.errorMessage = "Error";
            }
            return serviceResp;
        }


        /*public async Task<IActionResult> DeleteHead(int Id)
        {
            var result = await _majorHeadService.DeleteHead(Id);

            if (!result)
            {
                return NotFound($"MajorHead with ID {Id} not found");
            }

            return Ok($"MajorHead with ID {Id} has been deleted");
        }*/

        [HttpPut("MajorHeadUpdate/{Id}")]

        public async Task<ServiceResponse<bool>> UpdateHead(int Id, MajorHeadModel headdata)
        {
            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();
            try
            {
                serviceResponse.result = await _majorHeadService.UpdateHead(Id, headdata);
                serviceResponse.statusCode = HttpStatusCode.Found;
            }
            catch (Exception ex)
            {
                serviceResponse.statusCode = HttpStatusCode.BadRequest;
                serviceResponse.errorMessage = "Error";
            }
            return serviceResponse;
        }


        /*public async Task<IActionResult> UpdateHead(int Id, [FromBody] MajorHeadModel headdata)
        {
            var result = await _majorHeadService.UpdateHead(Id, headdata);

            if (!result)
            {
                return NotFound($"MajorHead with ID {Id} not found");
            }

            return Ok($"MajorHead with ID {Id} has been updated");
        }
        */


    }
}
