using IFMS_Master_Backend.BAL.IServices;
using IFMS_Master_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IFMS_Master_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubDetailHeadController : ControllerBase
    {
        private readonly ISubDetailHeadService _SubDetailHeadService;
        public SubDetailHeadController(ISubDetailHeadService SubDetailheadtService)
        {
            _SubDetailHeadService = SubDetailheadtService;
        }
        [HttpGet]
        public async Task<ServiceResponse<IEnumerable<SubDetailHeadModel>>> Get()
        {
            ServiceResponse<IEnumerable<SubDetailHeadModel>> response = new ServiceResponse<IEnumerable<SubDetailHeadModel>>();
            try
            {
                response.result = await _SubDetailHeadService.getAllSubDetail();
                response.statusCode = HttpStatusCode.OK;

            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.errorMessage = "Error";
            }
            return response;
        }
        [HttpGet("{Id}")]

        public async Task<ServiceResponse<SubDetailHeadModel>> GetSubDetailHead(int Id)
        {
            ServiceResponse<SubDetailHeadModel> response = new ServiceResponse<SubDetailHeadModel>();
            try
            {
                response.result = await _SubDetailHeadService.GetSubDetailHead(Id);
                response.statusCode = HttpStatusCode.Found;
            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.errorMessage = "Error";
            }
            return response;
        }

        [HttpPost("SubDetailHeadAdd")]

        public async Task<ServiceResponse<SubDetailHeadModel>> addSubDetailHead([FromBody] SubDetailHeadModel SubDe)
        {
            ServiceResponse<SubDetailHeadModel> response = new ServiceResponse<SubDetailHeadModel>();
            try
            {
                response.result = await _SubDetailHeadService.CreateSubDetail(SubDe);
                response.statusCode = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.errorMessage = "Error";
            }
            return response;
        }

        [HttpDelete("SubDetailHeadDelete/{Id}")]
        public async Task<ServiceResponse<bool>> DeleteSubDetail(int Id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                response.result = await _SubDetailHeadService.DeleteSubDetail(Id);
                response.statusCode = HttpStatusCode.NotFound;
            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.errorMessage = "Error";
            }
            return response;
        }

        [HttpPut("SubDetailUpdate/{Id}")]

        public async Task<ServiceResponse<bool>> UpdateSubDetail(int Id, [FromBody] SubDetailHeadModel Detl)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {


                response.result = await _SubDetailHeadService.UpdateSubDetail(Id, Detl);
                response.statusCode = HttpStatusCode.NotFound; // Set status code to indicate success
            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.errorMessage = "Error";
            }

            return response; // Return response with appropriate status code
        }


    }
}
