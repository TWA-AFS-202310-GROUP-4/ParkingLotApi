using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Models;
using ParkingLotApi.Request;
using ParkingLotApi.Requests;
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

        [HttpGet]
        public async Task<ActionResult<List<ParkingLot>>> GetParkingLotsListAsync([FromQuery] int? pageIndex)
        {
            if (pageIndex == null || pageIndex < 1)
            {
                pageIndex = 1;
            }

            return Ok(await parkingLotsService.GetParkingLotSAsync(pageIndex));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingLot>> GetParkingLotAsync(string id)
        {

            var res = await parkingLotsService.GetParkingLotByIdAsync(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLot>> CreateNewParkingLotAsync([FromBody] ParkingLotRequest parkingLotRequest)
        {
            return Created("", await parkingLotsService.AddParkingLotAsyn(parkingLotRequest));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExistedParkingLotAsync(string id)
        {
            await parkingLotsService.DeleteParkingLotByIdAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ParkingLot>> UpdateExistParkingLotAsync(string id, [FromBody] ParkingLotUpdateRequest parkingLotUpdateRequest)
        {
            return Ok(await parkingLotsService.UpdateParkingLotByIdAsync(id, parkingLotUpdateRequest));
        }
    }
}
