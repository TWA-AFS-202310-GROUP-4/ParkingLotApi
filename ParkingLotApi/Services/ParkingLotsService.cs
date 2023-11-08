using Microsoft.AspNetCore.Mvc;
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
            
            return await _parkingLotRepository.CreateParkingLot(parkingLotDto.ToModel());
            
        }
    }
}
