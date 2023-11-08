using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.DTOs;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotsController : ControllerBase
    {
        private readonly ParkingLotService _parkingLotSaervice;
        public ParkingLotsController(ParkingLotService parkingLotService)
        {
            this._parkingLotSaervice = parkingLotService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLotDTO>> CreateParkingLotAsync([FromBody] ParkingLotDTO parkingLotDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created,await _parkingLotSaervice.AddAsync(parkingLotDto));
            }
            catch (InvalidCapacityException ex)
            {
                return BadRequest();
            }
            return null;
        }
    }
}
