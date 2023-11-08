using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.DTO;
using ParkingLotApi.Request;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ParkingLotDTO>> CreateNewParkingLot([FromBody] ParkingLotRequest parkingLotRequest)
        {
            if (parkingLotRequest.Capacity < 10)
            {
                return BadRequest();
            }
            return Created("",new ParkingLotDTO(parkingLotRequest.Name, (int)parkingLotRequest.Capacity, parkingLotRequest.Location));
        }
    }
}
