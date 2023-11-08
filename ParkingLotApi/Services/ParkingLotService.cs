using ParkingLotApi.DTOs;
using ParkingLotApi.Exceptions;

namespace ParkingLotApi.Services
{
    public class ParkingLotService
    {
        public async Task<ParkingLotDto> CreateParkingLostAsync(ParkingLotDtoRequest parkingLotDtoRequest)
        {
            if (parkingLotDtoRequest.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }

            return null;
        }
    }
}
