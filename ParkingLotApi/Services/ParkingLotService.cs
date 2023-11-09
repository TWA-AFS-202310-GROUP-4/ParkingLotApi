using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Reposirities;

namespace ParkingLotApi.Services
{
    public class ParkingLotService
    {
        private readonly IParkingLotRepository _parkingLotRepository;

        public ParkingLotService(IParkingLotRepository parkingLotRepository)
        {
            this._parkingLotRepository = parkingLotRepository;
        }

        public async Task<ParkingLot> AddAsync(ParkingLotDto data)
        {
            if (data.Capacity < 10) throw new InvalidCapacityException();

            var checkName = _parkingLotRepository.GetParkingLotByName(data.Name);
            if (checkName != null) throw new InvalidNameException();

            return await _parkingLotRepository.CreateParkingLot(data.ToEntity());
        }

        public async Task DeleteAsync(string id) => await _parkingLotRepository.DeleteParkingLot(id);

        public async Task<List<ParkingLot>> GetPartialAsync(int pageSize, int pageIndex)
        {
            return await _parkingLotRepository.GetParkingLotPartial(pageSize, pageIndex);
        }

        public async Task<ParkingLot> GetByIdAsync(string id)
        {
            var parkingLot = await _parkingLotRepository.GetParkingLotById(id);
            if (parkingLot == null) throw new InvalidIdException();
            return parkingLot;
        }

        public async Task<ParkingLot> UpdateByIdAsync(string id, ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity != 0 && parkingLotDto.Capacity < 10) throw new InvalidCapacityException();
            if (parkingLotDto.Name != null)
            {
                var checkName = await _parkingLotRepository.GetParkingLotByName(parkingLotDto.Name);
                if (checkName != null) throw new InvalidNameException();
            }
            return await _parkingLotRepository.UpdateParkingLot(id, parkingLotDto.ToEntity());
        }
    }
}
