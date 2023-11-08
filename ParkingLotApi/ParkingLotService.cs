using ParkingLotApi.DTOs;

namespace ParkingLotApi
{
    public class ParkingLotService
    {
        public async Task<ParkingLotDTO> AddAsync(ParkingLotDTO parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new ArgumentException();
            }

            return null;
        }
    }
}
