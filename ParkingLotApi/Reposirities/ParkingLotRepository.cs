using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Models;


namespace ParkingLotApi.Reposirities
{
    public class ParkingLotRepository : IParkingLotRepository
    {
        private readonly IMongoCollection<ParkingLot> _parkingLotCollection;
        public ParkingLotRepository(IOptions<ParkingLotDatabaseSetting> parkingLotDatabaseSetting)
        {
            var mongoClient = new MongoClient(parkingLotDatabaseSetting.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(parkingLotDatabaseSetting.Value.DatabaseName);
            _parkingLotCollection = mongoDatabase.GetCollection<ParkingLot>(parkingLotDatabaseSetting.Value.CollectionName);
        }
        public async Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot)
        {
            await _parkingLotCollection.InsertOneAsync(parkingLot);
            return await _parkingLotCollection.Find(a => a.Name == parkingLot.Name).FirstAsync();
        }

        public async Task DeleteParkingLot(string id) => await _parkingLotCollection.DeleteOneAsync(a => a.Id == id);

        public async Task<List<ParkingLot>> GetPartial(int pageSize, int pageIndex)
        {
            var parkingLots = _parkingLotCollection.Find(_ => true).ToList();
            var pagedParkingLots = parkingLots.Skip((pageIndex) * pageSize).Take(pageSize).ToList();
            return pagedParkingLots;
        }
    }
}
