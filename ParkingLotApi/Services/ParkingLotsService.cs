using ParkingLotApi.Models;
using ParkingLotApi.Repository;
using ParkingLotApi.Request;
using ParkingLotApi.Requests;

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

        public async Task<bool> DeleteParkingLotByIdAsync(string id)
        {
            return await parkingLotRepository.DeleteParkingLotAsync(id);
        }

        public async Task<List<ParkingLot>> GetParkingLotSAsync(int? pageIndex)
        {
            return await parkingLotRepository.GetParkingLotByPageIndexAsync(pageIndex);
        }

        public async Task<ParkingLot> GetParkingLotByIdAsync(string id)
        {
            return await parkingLotRepository.GetParkingLotAsync(id);
        }

        public async Task<ParkingLot> UpdateParkingLotByIdAsync(string id,ParkingLotUpdateRequest parkingLotUpdateRequest)
        {
            if(parkingLotUpdateRequest.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }
            return await parkingLotRepository.UpdateParkingLotInfoByIdAsync(id,parkingLotUpdateRequest);
        }
    }
}
