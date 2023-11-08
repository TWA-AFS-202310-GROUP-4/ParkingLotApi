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
        public async Task<ActionResult<ParkingLot>> CreateAsync([FromBody] ParkingLotDto parkingLotDto)
        {

            return StatusCode(StatusCodes.Status201Created, await _parkingLotsService.CreateAsync(parkingLotDto));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingLot>> GetByIdAsync(string id)
        {
            return StatusCode(StatusCodes.Status200OK, await _parkingLotsService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<ActionResult<List<ParkingLot>>> GetAllAsync(int? pageIndex, int? pageSize = 15)
        {
            return StatusCode(StatusCodes.Status200OK, await _parkingLotsService.GetAllAsync(pageIndex,pageSize));
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            
            await  _parkingLotsService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(string id, [FromBody] ParkingLotDto parkingLotDto)
        {

            await _parkingLotsService.UpdateAsync(id,parkingLotDto);
            return NoContent();
        }
    }
}
