using ParkingLotApi.DTOs;

namespace ParkingLotApi.Interfaces
{
    public interface IParkingLotRepository
    {
        Task<ParkingLotEntity> AddOneAsync(ParkingLotEntity parkingLotDto);
        Task<long> DeleteByIdAsync(string id);
        Task<List<ParkingLotEntity>> GetAllAsync();
        Task<ParkingLotEntity> GetByIdAsync(string id);
        Task<ParkingLotEntity> GetByNameAsync(string name);
        Task<List<ParkingLotEntity>> GetByPageIndexAndPageSizeAsync(int pageIndex, int pageSize);
        Task<ParkingLotEntity> UpdateByIdAsync(ParkingLotEntity parkingLotDto);
    }
}