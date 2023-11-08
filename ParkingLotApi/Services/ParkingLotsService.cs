using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Repositories;

namespace ParkingLotApi.Services;

public class ParkingLotsService
{
    private readonly IParkingLotsRepository _parkingLotsRepository;

    public ParkingLotsService(IParkingLotsRepository parkingLotsRepository)
    {
        this._parkingLotsRepository = parkingLotsRepository;
    }

    public async Task<ParkingLot> AddParkingLotAsyncAsync(ParkingLotsDto parkingLotDto)
    {
        if (parkingLotDto.Capacity < 10)
        {
            throw new InvalidCapacityException();
        }

        return await _parkingLotsRepository.CreateParkingLotAsync(parkingLotDto.ToEntity());
    }

    public async Task DeleteAParkingLotAsync(string id)
    {
        await _parkingLotsRepository.DeleteAParkingLotAsync(id);
    }

    public async Task<List<ParkingLot>> GetParkingLotsAsync(int pageNumber)
    {
        return await _parkingLotsRepository.GetParkingLotsAsync(pageNumber);
    }

    public async Task<ParkingLot> GetParkingLotByIdAsync(string id)
    {
        return await _parkingLotsRepository.GetParkingLotByIdAsync(id);
    }

    public async Task<ParkingLot> UpdateCapacityAsync(string id, int capacity)
    {
        return await _parkingLotsRepository.UpdateCapacityAsync(id, capacity);
    }
}
