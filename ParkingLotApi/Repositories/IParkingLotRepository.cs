using ParkingLotApi.DTOs;
using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public interface IParkingLotRepository
    {
        public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot);
        public Task<bool> DeleteParkingLot(string id);
        public Task<List<ParkingLot>> GetParkingLotByPageIndex(int pageIndex, int pageSize);
        public Task<ParkingLot> GetParkingLotById(string id);
        public Task<ParkingLot> UpdateParkingLotById(string id, int capacity);
        public Task<ParkingLot> GetParkingLotByName(string name);
    }
}
