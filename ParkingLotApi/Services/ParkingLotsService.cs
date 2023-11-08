using ParkingLotApi.DTO;
using ParkingLotApi.Request;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        public async Task<ParkingLotDTO> AddParkingLotAsyn(ParkingLotRequest parkingLotRequest)
        {
            if (parkingLotRequest.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }
            return new ParkingLotDTO(parkingLotRequest.Name, (int)parkingLotRequest.Capacity, parkingLotRequest.Location);
        }
    }
}
