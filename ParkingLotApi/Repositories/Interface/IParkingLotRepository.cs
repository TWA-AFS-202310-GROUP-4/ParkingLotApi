using ParkingLotApi.Dtos;
using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories.Interface
{
    public interface IParkingLotRepository
    {

        public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot); 
    }
}
