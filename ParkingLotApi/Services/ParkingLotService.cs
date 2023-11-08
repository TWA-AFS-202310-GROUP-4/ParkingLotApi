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
    }
}
