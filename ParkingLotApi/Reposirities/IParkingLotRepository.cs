using ParkingLotApi.Dtos;
using ParkingLotApi.Models;

namespace ParkingLotApi.Reposirities
{
    public interface IParkingLotRepository
    {
        public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot);
        public Task DeleteParkingLot(string id);
        public Task<List<ParkingLot>> GetParkingLotPartial(int pageSize, int pageIndex);
        public Task<ParkingLot> GetParkingLotById(string id);
        public Task<ParkingLot> UpdateParkingLot(string id, ParkingLot parkingLot);
        public Task<ParkingLot> GetParkingLotByName(string name);
    }
}
