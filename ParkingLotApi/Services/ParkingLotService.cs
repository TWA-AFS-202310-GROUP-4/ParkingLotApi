using ParkingLotApi.DTOs;
using ParkingLotApi.Exceptions;

namespace ParkingLotApi.Services
{
    public class ParkingLotService
    {
        public async Task<ParkingLotDTO> AddAsync(ParkingLotDTO parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }

            return null;
        }
    }
}
