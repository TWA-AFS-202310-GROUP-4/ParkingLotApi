using ParkingLotApi.Dtos;

namespace ParkingLotApi.Services;

public class ParkingLotsService
{
    public async Task<ParkingLotsRequestDto> AddParkingLotAsync(ParkingLotsRequestDto parkingLotDto)
    {
        if (parkingLotDto.Capacity < 10)
        {
            throw new ArgumentException();
        }

        return null;
    }
}
