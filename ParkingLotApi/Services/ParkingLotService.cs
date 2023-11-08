using Microsoft.AspNetCore.Http.HttpResults;
using ParkingLotApi.DTOs;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Repositories;

namespace ParkingLotApi.Services
{
    public class ParkingLotService
    {
        private readonly IParkingLotRepository _parkingLotRepository;
        public ParkingLotService(IParkingLotRepository parkingLotRepository)
        {
            this._parkingLotRepository = parkingLotRepository;
        }
        public async Task<ParkingLot> AddAsync(ParkingLotDTO parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }

            return await _parkingLotRepository.CreateParkingLot(parkingLotDto.ToEntity());
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _parkingLotRepository.DeleteParkingLot(id);
        }

        public async Task<List<ParkingLot>> GetParkingLotByPageSizeAsync(int? pageIndex, int pageSize)
        {

            List<ParkingLot> parkingLots = await _parkingLotRepository.GetParkingLot();

            return  parkingLots.Skip(((int)pageIndex - 1) * (int)pageSize).Take((int)pageSize).ToList();
        }

        public async Task<ParkingLot> GetParkingLotById(string id)
        {
            return await _parkingLotRepository.GetParkingLotById(id);
        }

        public async Task<ParkingLot> UpdateParkingLotById(string id, int capacity)
        {
            if (capacity < 10)
            {
                throw new InvalidCapacityException();
            }
            return await _parkingLotRepository.UpdateParkingLotById(id, capacity);
        }
    }
}
