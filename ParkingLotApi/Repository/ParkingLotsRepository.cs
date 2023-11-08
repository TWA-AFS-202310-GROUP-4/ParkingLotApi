using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Models;
using ParkingLotApi.Requests;

namespace ParkingLotApi.Repository
{
    public class ParkingLotsRepository : IParkingLotsRepository
    {
        private readonly IMongoCollection<ParkingLot> _parkingLotCollection;
        private static readonly int _pageSize = 15;
        public ParkingLotsRepository(IOptions<ParkingLotDatabaseSettings> parkingLotDatabaseSettings)
        {
            var mongoClient = new MongoClient(parkingLotDatabaseSettings.Value.ConnectionString);
            var mangoDatabase = mongoClient.GetDatabase(parkingLotDatabaseSettings.Value.DataBaseName);
            _parkingLotCollection = mangoDatabase.GetCollection<ParkingLot>(parkingLotDatabaseSettings.Value.CollectionName);
        }

        public async Task<ParkingLot> AddParkingLotAsync(ParkingLot parkingLotDTO)
        {

            await _parkingLotCollection.InsertOneAsync(parkingLotDTO);
            return await _parkingLotCollection.Find(parkingLot => parkingLot.Name == parkingLotDTO.Name).FirstAsync();
        }

        public async Task<bool> DeleteParkingLotAsync(string id)
        {
            var res = await _parkingLotCollection.DeleteOneAsync(parkingLot => parkingLot.Id == id);
            if (res.DeletedCount == 0)
            {
                throw new InvalidIdException();
            }
            return true;
        }

        public async Task<List<ParkingLot>> GetParkingLotByPageIndexAsync(int? pageIndex)
        {
            return await _parkingLotCollection.Find(Builders<ParkingLot>.Filter.Empty).Skip((pageIndex - 1) * _pageSize).Limit(_pageSize).ToListAsync();
        }

        public async Task<ParkingLot> GetParkingLotAsync(string id)
        {
            var res = await _parkingLotCollection.Find(parkingLot => parkingLot.Id == id).FirstOrDefaultAsync();
            return res == null ? throw new InvalidIdException() : res;
        }

        public async Task<ParkingLot> UpdateParkingLotInfoByIdAsync(string id, ParkingLotUpdateRequest parkingLotUpdateRequest)
        {
            var originParkingLot = await GetParkingLotAsync(id);
            var updatedLot = new ParkingLot()
            {
                Id = id,
                Name = originParkingLot.Name,
                Capacity = parkingLotUpdateRequest.Capacity,
                Location = originParkingLot.Location,
            };
            await _parkingLotCollection.ReplaceOneAsync(parkinglot=>parkinglot.Id==id, updatedLot);
            return updatedLot;
        }
    }
}
