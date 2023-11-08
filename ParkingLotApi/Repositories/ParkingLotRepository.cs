using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using ParkingLotApi.Models;
using System.Security.Cryptography;

namespace ParkingLotApi.Repositories
{
    public class ParkingLotRepository:IParkingLotRepository
    {
        private readonly  IMongoCollection<ParkingLot> _parkingLotCollection;

        public ParkingLotRepository(IOptions<ParkinglotDatabaseSettings> parkingLotDatabaseSetting)
        {
            var mongoClient = new MongoClient(parkingLotDatabaseSetting.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(parkingLotDatabaseSetting.Value.DatabaseName);
            _parkingLotCollection =
                mongoDatabase.GetCollection<ParkingLot>(parkingLotDatabaseSetting.Value.CollectionName);
        }

        public async Task<ParkingLot> CreateParkingLot(ParkingLot parkinglot)
        {
            await _parkingLotCollection.InsertOneAsync(parkinglot);
            return await _parkingLotCollection.Find(parking => parking.Id == parkinglot.Id).FirstAsync();
        }
        
        public async Task<bool> DeleteParkingLot(string id)
        {
            var result = _parkingLotCollection.DeleteOneAsync(parkinglot => parkinglot.Id == id).Result;
            return result.DeletedCount > 0 ;
            
        }

        public async Task<List<ParkingLot>> GetParkingLot()
        {
            return await _parkingLotCollection.Find(_ => true).ToListAsync();
        }

        public async Task<ParkingLot> GetParkingLotById(string id)
        {
            return await _parkingLotCollection.Find(parkingLot => parkingLot.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ParkingLot> UpdateParkingLotById(string id, int capacity)
        {
            var update = Builders<ParkingLot>.Update.Set("Capacity", capacity);
            await _parkingLotCollection.UpdateOneAsync(parkingLot => parkingLot.Id == id,
                update);
            return await _parkingLotCollection.Find(parkingLot => parkingLot.Id == id).FirstOrDefaultAsync();
        }
    }
}
