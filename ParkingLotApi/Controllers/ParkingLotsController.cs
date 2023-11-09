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
        private readonly ParkingLotService _parkingLotService;
        private const int PageSize = 15;
        public ParkingLotsController(ParkingLotService parkingLotService)
        {
            this._parkingLotService = parkingLotService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLotDTO>> CreateParkingLotAsync([FromBody] ParkingLotDTO parkingLotDto)
        {

            return StatusCode(StatusCodes.Status201Created, await _parkingLotService.AddAsync(parkingLotDto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteParkingLotAsync(string id)
        {
            bool isSuccess = await _parkingLotService.DeleteAsync(id);
            if (isSuccess)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<List<ParkingLot>>> GetParkingLotByPage([FromQuery] int pageIndex)
        {
          
            return StatusCode(StatusCodes.Status200OK,
                await _parkingLotService.GetParkingLotByPageSizeAsync(pageIndex, PageSize));


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingLot>> GetParkingLotById(string id)
        {
            var result = await _parkingLotService.GetParkingLotById(id);
            if (result == null)
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status200OK, result);
;        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ParkingLot>> UpdateParkingLotAsync(string id, [FromBody] ParkingLotWithCapacityDTO parkingLotWithCapacity)
        {
            var result =await _parkingLotService.UpdateParkingLotById(id, parkingLotWithCapacity.Capacity);
            if (result == null)
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
