using ParkingLotApi.Models;
using ParkingLotApi.Repository;
using ParkingLotApi.Request;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        private readonly IParkingLotsRepository parkingLotRepository;
        public ParkingLotsService(IParkingLotsRepository parkingLotRepository)
        {
            this.parkingLotRepository = parkingLotRepository;
        }
        public async Task<ParkingLot> AddParkingLotAsyn(ParkingLotRequest parkingLotRequest)
        {
            if (parkingLotRequest.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }
            return await parkingLotRepository.AddParkingLot(parkingLotRequest.ToEntity());
        }
    }
}
