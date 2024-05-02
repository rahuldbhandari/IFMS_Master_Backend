using IFMS_Master_Backend.BAL.Interface;
using IFMS_Master_Backend.BAL.Services;
using IFMS_Master_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IFMS_Master_Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DdoModelController : ControllerBase
    {
        private readonly IDdoService _DdoService;
        public DdoModelController(IDdoService DdoService)
        {
            _DdoService = DdoService;
        }
        [HttpGet]
        public async Task<ServiceResponse<IEnumerable<DdoModel>>> Get()
        {
            ServiceResponse<IEnumerable<DdoModel>> response = new ServiceResponse<IEnumerable<DdoModel>>();
            try
            {
                response.result = await _DdoService.getAllDetail();
                response.statusCode = HttpStatusCode.OK;

            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.errormessage = "Error";
            }
            return response;

        }

        /*public async Task<ServiceResponse<DdoModel>> GetAllDetailsDdoData(int Id)
        {
            ServiceResponse<DdoModel> response = new ServiceResponse<DdoModel>();
            try
            {
                response.result = await _DdoService.GetAllDetailsDdoData(Id);
                response.statusCode = HttpStatusCode.Found;
            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.errormessage = "Error";
            }
            return response;

        }*/


        [HttpPost("ddo-add")]



        public async Task<ServiceResponse<DdoModel>> addDdo([FromBody] DdoModel dr)
        {
            ServiceResponse<DdoModel> response = new ServiceResponse<DdoModel>();
            try
            {
                response.result = await _DdoService.CreateDdo(dr);
                response.statusCode = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.errormessage = "Error";
            }
            return response;
        }

        [HttpDelete("ddo-delete/{Id}")]
        public async Task<ServiceResponse<bool>> DeleteDdo(int Id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                response.result = await _DdoService.DeleteDdo(Id);
                response.statusCode = HttpStatusCode.OK;
            }

            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.errormessage = "Error";
            }
            return response;
        }
        [HttpGet("{Id}")]

        public async Task<ServiceResponse<DdoModel>> GetDdoDetail(int Id)
        {
            ServiceResponse<DdoModel> response = new ServiceResponse<DdoModel>();
            try
            {
                response.result = await _DdoService.GetDdoDetail(Id);
                response.statusCode = HttpStatusCode.Found;
            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.errormessage = "Error";
            }
            return response;
        }
        [HttpPut("ddo-update/{Id}")] // Corrected route declaration
        public async Task<ServiceResponse<bool>> UpdateDetail(int Id, [FromBody] DdoModel Detl)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {


                response.result = await _DdoService.UpdateDdo(Id, Detl);
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
