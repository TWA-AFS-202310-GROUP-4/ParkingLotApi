using MongoDB.Bson;
using ParkingLotApi.Dtos;
using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories.Interface
{
    public interface IParkingLotRepository
    {

        public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot); 

        public Task<ParkingLot> GetByName(string name);

        public Task DeleteById(string id);
        public Task<ParkingLot> GetById(string id);
        Task<List<ParkingLot>> GetAll(int? pageIndex, int? pageSize);
    }
}
