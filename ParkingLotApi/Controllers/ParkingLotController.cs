using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
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
            try
            {
                var ret = await _service.AddAsync(data);
                return StatusCode(StatusCodes.Status201Created, ret);
            }
            catch (InvalidCapacityException ex)
            {
                return BadRequest();
            }
            
        }
    }
}