using ParkingLotApi.Models;

namespace ParkingLotApi.Reposirities
{
    public interface IParkingLotRepository
    {
        public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot);
        public Task DeleteParkingLot(string id);
        public Task<List<ParkingLot>> GetPartial(int pageSize, int pageIndex);
        public Task<ParkingLot> GetById(string id);
    }
}
