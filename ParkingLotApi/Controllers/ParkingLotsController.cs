using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.DTOs;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotsController : ControllerBase
    {
        private readonly ParkingLotService _parkingLotSaervice;
        private readonly int pageSize = 15;
        public ParkingLotsController(ParkingLotService parkingLotService)
        {
            this._parkingLotSaervice = parkingLotService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLotDTO>> CreateParkingLotAsync([FromBody] ParkingLotDTO parkingLotDto)
        {

            return StatusCode(StatusCodes.Status201Created, await _parkingLotSaervice.AddAsync(parkingLotDto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteParkingLotAsync(string id)
        {
            bool isSuccess = _parkingLotSaervice.DeleteAsync(id).Result;
            if (isSuccess)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<List<ParkingLot>>> GetParkingLotByPage([FromQuery] int? pageIndex)
        {
            if (pageIndex < 1 || pageIndex == null)
            {
                return BadRequest();
            }

            return StatusCode(StatusCodes.Status200OK,
                await _parkingLotSaervice.GetParkingLotByPageSizeAsync(pageIndex, pageSize));


        }
    }
}
