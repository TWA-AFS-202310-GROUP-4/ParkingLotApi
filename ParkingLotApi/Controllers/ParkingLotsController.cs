using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.DTOs;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ParkingLotDto>> CreateParkingLot([FromBody] ParkingLotDtoRequest parkingLotDtoRequest)
        {
            if (parkingLotDtoRequest.Capacity < 10)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
