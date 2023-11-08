using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories;

public interface IParkingLotsRepository
{
    public Task<ParkingLot> CreateParkingLotAsync(ParkingLot parkingLot);

    public Task DeleteAParkingLotAsync(string id);

    public Task<List<ParkingLot>> GetParkingLotsAsync(int pageNumber);

    public Task<ParkingLot> GetParkingLotByIdAsync(string id);

    public Task<ParkingLot> UpdateCapacityAsync(string id, int capacity);
}
