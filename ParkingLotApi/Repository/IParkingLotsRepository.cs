using ParkingLotApi.Models;
using ParkingLotApi.Request;
using ParkingLotApi.Requests;

namespace ParkingLotApi.Repository
{
    public interface IParkingLotsRepository
    {
        Task<ParkingLot> AddParkingLot(ParkingLot parkingLotDTO);
        Task<bool> DeleteParkingLotAsync(string id);
        Task<ParkingLot> GetParkingLotAsync(string id);
        Task<List<ParkingLot>> GetParkingLotByPageIndexAsync(int? pageIndex);
        Task<ParkingLot> UpdateParkingLotInfoByIdAsync(string id, ParkingLotUpdateRequest parkingLotUpdateRequest);
    }
}
