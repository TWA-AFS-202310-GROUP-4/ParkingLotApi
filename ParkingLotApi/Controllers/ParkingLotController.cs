using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotController : ControllerBase
    {
        private readonly ParkingLotService _service;
        public ParkingLotController(ParkingLotService service)
        {
            this._service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLotDto>> AddParkingLotAsync([FromBody] ParkingLotDto data)
        {
            return StatusCode(StatusCodes.Status201Created, await _service.AddAsync(data));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteParkingLotAsync(string id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<ParkingLot>>> GetPartialAsync(int? pageSize = 10, int? pageIndex = 0)
        {
            return StatusCode(StatusCodes.Status200OK, await _service.GetPartialAsync((int)pageSize, (int)pageIndex));
        }
    }
}