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
            if (data.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }

            return await _parkingLotRepository.CreateParkingLot(data.ToEntity());
        }

        public async Task DeleteAsync(string id) => await _parkingLotRepository.DeleteParkingLot(id);
    }
}
