using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exception;
using ParkingLotApi.Models;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ParkingLotsController : ControllerBase
    {
        
        private readonly ParkingLotsService _parkingLotsService;

        public ParkingLotsController(ParkingLotsService parkingLotsService)
        {
            _parkingLotsService = parkingLotsService;
        }


        [HttpPost]
        public async Task<ActionResult<ParkingLot>> CreateAsync([FromBody]ParkingLotDto parkingLotDto)
        {

            return StatusCode(StatusCodes.Status201Created, await _parkingLotsService.CreateAsync(parkingLotDto));
        }

        [HttpGet]
        public async Task<ActionResult<ParkingLot>> GetByNameAsync(string name)
        {
            

            return Ok();
        }
    }
}
