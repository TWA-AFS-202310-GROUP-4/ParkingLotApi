using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Models;

namespace ParkingLotApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ParkingLotsController : ControllerBase
    {
        

        public ParkingLotsController() { }


        [HttpPost]
        public async Task<ActionResult<ParkingLot>> Create([FromBody]ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10) return BadRequest();
            
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<ParkingLot>> GetByName(string name)
        {
            

            return Ok();
        }
    }
}
