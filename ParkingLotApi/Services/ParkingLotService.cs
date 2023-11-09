using Microsoft.AspNetCore.Http.HttpResults;
using ParkingLotApi.DTOs;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Repositories;

namespace ParkingLotApi.Services
{
    public class ParkingLotService
    {
        private const int Capacity = 10;
        private readonly IParkingLotRepository _parkingLotRepository;
        public ParkingLotService(IParkingLotRepository parkingLotRepository)
        {
            this._parkingLotRepository = parkingLotRepository;
        }
        public async Task<ParkingLot> AddAsync(ParkingLotDTO parkingLotDto)
        {
            if (parkingLotDto.Capacity < Capacity)
            {
                throw new InvalidCapacityException();
            }

            var result = await _parkingLotRepository.GetParkingLotByName(parkingLotDto.Name);
            if (result == null)
            {
                throw new DuplicateNameException();
            }
            return await _parkingLotRepository.CreateParkingLot(parkingLotDto.ToEntity());
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _parkingLotRepository.DeleteParkingLot(id);
        }

        public async Task<List<ParkingLot>> GetParkingLotByPageSizeAsync(int pageIndex, int pageSize)
        {
            if (pageIndex <= 0)
            {
                throw new InvalidPageIndexException();
            }
            return await _parkingLotRepository.GetParkingLotByPageIndex(pageIndex, pageSize);
        }

        public async Task<ParkingLot> GetParkingLotById(string id)
        {
            return await _parkingLotRepository.GetParkingLotById(id);
        }

        public async Task<ParkingLot> UpdateParkingLotById(string id, int capacity)
        {
            if (capacity < Capacity)
            {
                throw new InvalidCapacityException();
            }
            return await _parkingLotRepository.UpdateParkingLotById(id, capacity);
        }
    }
}
