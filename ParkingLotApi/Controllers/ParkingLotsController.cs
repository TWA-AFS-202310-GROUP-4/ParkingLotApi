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
        public async Task<ActionResult<ParkingLotEntity>> CreateParkingLotAsync([FromBody] ParkingLotRequest parkingLotDtoRequest)
        {
            ParkingLotEntity lot;
            lot = await parkingLotService.CreateParkingLostAsync(parkingLotDtoRequest);

            return StatusCode(StatusCodes.Status201Created, lot);
        }

        [HttpGet]
        public async Task<ActionResult<List<ParkingLotEntity>>> GetByPageIndex([FromQuery] int pageIndex)
        {
            var lots = await this.parkingLotService.GetByPageIndexAsync(pageIndex);

            return StatusCode(StatusCodes.Status200OK, lots);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingLotEntity>> GetByIdAsync(string id)
        {
            var lot = await this.parkingLotService.GetByIdAsync(id);

            return StatusCode(StatusCodes.Status200OK, lot);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(string id)
        {
            await this.parkingLotService.DeleteByIdAsync(id);

            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpPut]
        public async Task<ActionResult<ParkingLotEntity>> UpdateById(ParkingLotEntity parkingLotDto)
        {
            var lot = await this.parkingLotService.UpdateByIdAsync(parkingLotDto);

            return StatusCode(StatusCodes.Status200OK, lot);
        }
    }
}
