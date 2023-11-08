using ParkingLotApi.Models;

namespace ParkingLotApi.Reposirities
{
    public interface IParkingLotRepository
    {
        public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot);
        public Task DeleteParkingLot(string id);
    }
}
