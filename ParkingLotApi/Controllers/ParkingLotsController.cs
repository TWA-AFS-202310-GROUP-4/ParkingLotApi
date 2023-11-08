using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.DTOs;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotsController:ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ParkingLotDTO>> CreateParkingLotAsync([FromBody] ParkingLotDTO parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                return BadRequest();
            }

            return null;
        } 
    }
}
