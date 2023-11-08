using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories;

public interface IParkingLotsRepository
{
    public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot);

    public Task DeleteAParkingLot(string id);

    public Task<List<ParkingLot>> GetParkingLots(int pageNumber);

    public Task<ParkingLot> GetParkingLotById(string id);
}
