using Microsoft.Extensions.Options;
using MongoDB.Bson;
using ParkingLotApi.DTOs;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Interfaces;

namespace ParkingLotApi.Services
{
    public class ParkingLotService
    {
        private IParkingLotRepository _parkingLotRepository;
        public ParkingLotService( IParkingLotRepository parkingLotRepository)
        {
            this._parkingLotRepository = parkingLotRepository;
        }

        public async Task<ParkingLotDto> CreateParkingLostAsync(ParkingLotDtoRequest parkingLotDtoRequest)
        {
            await ValidateCapacityAndName(parkingLotDtoRequest.Capacity, parkingLotDtoRequest.Name);

            var parkingLot = new ParkingLotDto(parkingLotDtoRequest);
            return await _parkingLotRepository.AddOneAsync(parkingLot);
        }

        public async Task<List<ParkingLotDto>> GetAllAsync()
        {
            return await _parkingLotRepository.GetAllAsync();
        }

        public async Task<List<ParkingLotDto>> GetByPageIndexAsync(int pageIndex ,int pageSize = 15)
        {
            if (pageIndex < 1)
            {
                throw new InvalidCapacityException();
            }
            var res = await GetAllAsync();
            return res.Skip((pageIndex-1) * pageSize).Take(pageSize).ToList();
        }

        public async Task DeleteByIdAsync(string id)
        {
            await _parkingLotRepository.DeleteByIdAsync(id);
        }

        public async Task<ParkingLotDto> UpdateByIdAsync(ParkingLotDto parkingLotDto)
        {
            await ValidateCapacityAndName(parkingLotDto.Capacity, parkingLotDto.Name);
            var lot = await _parkingLotRepository.UpdateByIdAsync(parkingLotDto);
            if (lot == null)
            {
                throw new InvalidParkingLotNameOrIdException();
            }

            return lot;
        }

        public async Task<ParkingLotDto> GetByNameAsync(string name)
        {
            var lot = await _parkingLotRepository.GetByNameAsync(name);
            if (lot == null)
            {
                throw new InvalidParkingLotNameOrIdException();
            }

            return lot;
        }

        public async Task<ParkingLotDto> GetByIdAsync(string id)
        {
            if (!ObjectId.TryParse(id, out _))
            {
                throw new InvalidParkingLotNameOrIdException();
            }
            var lot  = await _parkingLotRepository.GetByIdAsync(id);
            if (lot == null)
            {
                throw new InvalidParkingLotNameOrIdException();
            }
            return lot;
        }

        private async Task ValidateCapacityAndName(int capacity, string name)
        {
            if (capacity < 10)
            {
                throw new InvalidCapacityException();
            }

            var existedParkingLot = await _parkingLotRepository.GetByNameAsync(name);
            if (existedParkingLot != null)
            {
                throw new RepeatParkingLotNameOrIdException();
            }
        }
    }
}
