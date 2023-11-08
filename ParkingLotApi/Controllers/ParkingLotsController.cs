using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.DTO;
using ParkingLotApi.Request;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotsController : ControllerBase
    {
        private readonly ParkingLotsService parkingLotsService;
        public ParkingLotsController(ParkingLotsService parkingLotsService)
        {
            this.parkingLotsService = parkingLotsService;
        }


        [HttpPost]
        public async Task<ActionResult<ParkingLotDTO>> CreateNewParkingLotAsync([FromBody] ParkingLotRequest parkingLotRequest)
        {
            try
            {
                return Created("", await parkingLotsService.AddParkingLotAsyn(parkingLotRequest));
            }
            catch (ArgumentException ex)
            {
                return BadRequest();
            }
        }
    }
}
