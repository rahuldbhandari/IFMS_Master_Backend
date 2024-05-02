using IFMS_Master_Backend.BAL.Interfaces;
using IFMS_Master_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IFMS_Master_Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DetailHeadController : ControllerBase
    {
        private readonly IDetailHeadService _DetailHeadService;
        public DetailHeadController(IDetailHeadService DetailheadtService)
        {
            _DetailHeadService = DetailheadtService;
        }
        [HttpGet]
        public async Task<ServiceResponse<IEnumerable<DetailHeadModel>>> Get()
        {
            ServiceResponse<IEnumerable<DetailHeadModel>> response = new ServiceResponse<IEnumerable<DetailHeadModel>>();
            try
            {
                response.result = await _DetailHeadService.getAllDetail();
                response.statusCode = HttpStatusCode.OK;

            }
            catch (Exception ex) {
                response.statusCode = HttpStatusCode.BadRequest;
                response.errormessage = "Error";
            }
            return response;
            
        }
        [HttpPost("Detail_head-add")]

  

        public async Task<ServiceResponse<DetailHeadModel>> addDetailHead([FromBody] DetailHeadModel Detl)
        {
            ServiceResponse<DetailHeadModel> response = new ServiceResponse<DetailHeadModel>();
            try
            {
                response.result = await _DetailHeadService.CreateDetail(Detl);
                response.statusCode = HttpStatusCode.Created;
            }
          catch(Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.errormessage = "Error";
            }
            return response;
        }

        [HttpDelete("detail_head-delete/{Id}")]
        public async Task<ServiceResponse<bool>> DeleteDetail(int Id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                response.result = await _DetailHeadService.DeleteDetail(Id);
                response.statusCode = HttpStatusCode.OK;
            }

            catch(Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;    
                   response.errormessage = "Error";
            }
            return response;
        }

        [HttpGet("{Id}")]

        public async Task<ServiceResponse<DetailHeadModel>> GetDetailHead(int Id)
        {
            ServiceResponse<DetailHeadModel> response = new ServiceResponse<DetailHeadModel>();
            try
            {
                response.result = await _DetailHeadService.GetDetailHead(Id);
                response.statusCode = HttpStatusCode.Found;
            }
            catch(Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;    
                   response.errormessage = "Error";
            }
            return response;
        }

        [HttpPut("detail_head-update/{Id}")] // Corrected route declaration
        public async Task<ServiceResponse<bool>> UpdateDetail(int Id, [FromBody] DetailHeadModel Detl)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {


                response.result = await _DetailHeadService.UpdateDetail(Id,Detl);
                response.statusCode = HttpStatusCode.NotFound; // Set status code to indicate success
            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.errormessage = "Error";
            }

            return response; // Return response with appropriate status code
        }
    }
}

