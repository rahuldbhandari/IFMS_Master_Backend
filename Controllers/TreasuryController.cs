using IFMS_Master_Backend.BAL.IServices;
using IFMS_Master_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IFMS_Master_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreasuryController : ControllerBase
    {
        private readonly ITreasuryService _TreasuryService;
        public TreasuryController(ITreasuryService TreasuryService)
        {
            _TreasuryService = TreasuryService;
        }
        [HttpGet]
        public async Task<ServiceResponse<IEnumerable<TreasuryModel>>> Get()
        {
            ServiceResponse<IEnumerable<TreasuryModel>> response = new ServiceResponse<IEnumerable<TreasuryModel>>();
            try
            {
                response.result = await _TreasuryService.getAllDetail();
                response.statusCode = HttpStatusCode.OK;

            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.errorMessage = "Error";
            }
            return response;

        }


        [HttpPost("treasury-add")]

        public async Task<ServiceResponse<TreasuryModel>> addTreasury([FromBody] TreasuryModel tr)
        {
            ServiceResponse<TreasuryModel> response = new ServiceResponse<TreasuryModel>();
            try
            {
                response.result = await _TreasuryService.CreateTreasury(tr);
                response.statusCode = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.errorMessage = "Error";
            }
            return response;
        }

        [HttpDelete("treasury-delete/{Id}")]
        public async Task<ServiceResponse<bool>> DeleteTreasury(int Id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                response.result = await _TreasuryService.DeleteTreasury(Id);
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

        public async Task<ServiceResponse<TreasuryModel>> GetTreasuryDetail(int Id)
        {
            ServiceResponse<TreasuryModel> response = new ServiceResponse<TreasuryModel>();
            try
            {
                response.result = await _TreasuryService.GetTreasuryDetail(Id);
                response.statusCode = HttpStatusCode.Found;
            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.errorMessage = "Error";
            }
            return response;
        }
        [HttpPut("treasury-update/{Id}")] // Corrected route declaration
        public async Task<ServiceResponse<bool>> UpdateDetail(int Id, [FromBody] TreasuryModel Detl)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {


                response.result = await _TreasuryService.UpdateTreasury(Id, Detl);
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
