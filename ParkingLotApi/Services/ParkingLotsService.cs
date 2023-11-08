using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;

namespace ParkingLotApi.Services;

public class ParkingLotsService
{
    public async Task<ParkingLotsRequestDto> AddParkingLotAsync(ParkingLotsRequestDto parkingLotDto)
    {
        if (parkingLotDto.Capacity < 10)
        {
            throw new InvalidCapacityException();
        }

        return null;
    }
}
