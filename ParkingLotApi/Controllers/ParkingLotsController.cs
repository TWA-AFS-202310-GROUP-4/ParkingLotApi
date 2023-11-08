using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Services;
using ParkingLotApi.Exceptions;
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
        return StatusCode(StatusCodes.Status201Created, await _parkingLotsService.AddParkingLotAsync(parkingLotDto));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult>  DeleteAParkingLot(string id)
    {
       await _parkingLotsService.DeleteAParkingLot(id);
       return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<ParkingLotsDto>> ShowParkingLotsWithPagination([FromQuery] int pageIndex)
    {
        return StatusCode(StatusCodes.Status200OK, await _parkingLotsService.GetParkingLots(pageIndex));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ParkingLot>> GetAParkingLot(string id)
    {
        return StatusCode(StatusCodes.Status200OK, await _parkingLotsService.GetParkingLotById(id));
    }
}
