using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Services;
using ParkingLotApi.Models;

namespace ParkingLotApi.Controllers;

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
    public async Task<ActionResult<ParkingLotsDto>> AddNewParkingLotAsync([FromBody] ParkingLotsDto parkingLotDto)
    {
        return StatusCode(StatusCodes.Status201Created, await _parkingLotsService.AddParkingLotAsyncAsync(parkingLotDto));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult>  DeleteAParkingLotAsync(string id)
    {
       await _parkingLotsService.DeleteAParkingLotAsync(id);
       return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<ParkingLotsDto>> ShowParkingLotsWithPaginationAsync([FromQuery] int pageIndex)
    {
        return StatusCode(StatusCodes.Status200OK, await _parkingLotsService.GetParkingLotsAsync(pageIndex));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ParkingLot>> GetAParkingLotAsync(string id)
    {
        return StatusCode(StatusCodes.Status200OK, await _parkingLotsService.GetParkingLotByIdAsync(id));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCapacityAsync(string id, ParkingLotsDto parkingLotsDto)
    {
        return StatusCode(StatusCodes.Status200OK, await _parkingLotsService.UpdateCapacityAsync(id, parkingLotsDto.Capacity));
    }
}
