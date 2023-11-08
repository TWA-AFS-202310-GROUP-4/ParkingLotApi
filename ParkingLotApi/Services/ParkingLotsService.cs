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

    public async Task<ParkingLot> AddParkingLotAsync(ParkingLotsDto parkingLotDto)
    {
        if (parkingLotDto.Capacity < 10)
        {
            throw new InvalidCapacityException();
        }

        return await _parkingLotsRepository.CreateParkingLot(parkingLotDto.ToEntity());
    }

    public async Task DeleteAParkingLot(string id)
    {
        await _parkingLotsRepository.DeleteAParkingLot(id);
    }

    public async Task<List<ParkingLot>> GetParkingLots(int pageNumber)
    {
        return await _parkingLotsRepository.GetParkingLots(pageNumber);
    }

    public async Task<ParkingLot> GetParkingLotById(string id)
    {
        return await _parkingLotsRepository.GetParkingLotById(id);
    }

    public async Task<ParkingLot> UpdateCapacity(string id, int capacity)
    {
        return await _parkingLotsRepository.UpdateCapacity(id, capacity);
    }
}
