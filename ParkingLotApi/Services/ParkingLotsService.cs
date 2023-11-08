using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exception;
using ParkingLotApi.Models;
using ParkingLotApi.Repositories;
using ParkingLotApi.Repositories.Interface;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {

        private readonly IParkingLotRepository _parkingLotRepository;

        public ParkingLotsService(IParkingLotRepository parkingLotRepository)
        {
            _parkingLotRepository = parkingLotRepository;
        }
        public async Task<ParkingLot> CreateAsync( ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10) throw new InvaildCapacityException();

            var parkingLot = await _parkingLotRepository.GetByName(parkingLotDto.Name);

            if (parkingLot != null) throw new AlreadyExistParkingLotExpection();

            return await _parkingLotRepository.CreateParkingLot(parkingLotDto.ToModel());
        }

        public async Task DeleteAsync(string id)
        {
            
            var parkingLot = await _parkingLotRepository.GetById(id);
            
            if (parkingLot == null) throw new IdNotExistException();
      
            await _parkingLotRepository.DeleteById(id);
        }

        public async Task<ParkingLot> GetByIdAsync(string id)
        {
            var parkingLot = await _parkingLotRepository.GetById(id);
            if (parkingLot == null) throw new IdNotExistException();
            return parkingLot;
        }

        public async Task<List<ParkingLot>> GetAllAsync(int? pageIndex,int? pageSize)
        {
            return await _parkingLotRepository.GetAll(pageIndex, pageSize);

        }
    }
}
