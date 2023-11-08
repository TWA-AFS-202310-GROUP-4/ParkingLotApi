using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Models;
using ParkingLotApi.Request;

namespace ParkingLotApi.Repository
{
    public class ParkingLotsRepository : IParkingLotsRepository
    {
        private readonly IMongoCollection<ParkingLot> _parkingLotCollection;

        public ParkingLotsRepository(IOptions<ParkingLotDatabaseSettings> parkingLotDatabaseSettings)
        {
            var mongoClient = new MongoClient(parkingLotDatabaseSettings.Value.ConnectionString);
            var mangoDatabase = mongoClient.GetDatabase(parkingLotDatabaseSettings.Value.DataBaseName);
            _parkingLotCollection = mangoDatabase.GetCollection<ParkingLot>(parkingLotDatabaseSettings.Value.CollectionName);
        }

        public async Task<ParkingLot> AddParkingLot(ParkingLot parkingLotDTO)
        {
            
            await _parkingLotCollection.InsertOneAsync(parkingLotDTO);
            return await _parkingLotCollection.Find(parkingLot => parkingLot.Name == parkingLotDTO.Name).FirstAsync();
        }
    }
}
