using ParkingLotApi.DTOs;

namespace ParkingLotApi.Interfaces
{
    public interface IParkingLotRepository
    {
        Task<ParkingLotDto> AddOneAsync(ParkingLotDto parkingLotDto);
        Task DeleteByIdAsync(string id);
        Task<List<ParkingLotDto>> GetAllAsync();
        Task<ParkingLotDto> GetByIdAsync(string id);
        Task<ParkingLotDto> GetByNameAsync(string name);
        Task<ParkingLotDto> UpdateByIdAsync(ParkingLotDto parkingLotDto);
    }
}