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
        private readonly ParkingLotService parkingLotService;

        public ParkingLotsController(ParkingLotService parkingLotService)
        {
            this.parkingLotService = parkingLotService;   
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLotDto>> CreateParkingLotAsync([FromBody] ParkingLotDtoRequest parkingLotDtoRequest)
        {
            ParkingLotDto lot;
            try
            {
                lot = await parkingLotService.CreateParkingLostAsync(parkingLotDtoRequest);
            }
            catch(InvalidCapacityException)
            {
                return BadRequest();
            }

            return Created("", lot);
        }
    }
}
