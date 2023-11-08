using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Dtos;
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

        public async Task<ParkingLot> GetParkingLotById(string id) => await _parkingLotCollection.Find(a => a.Id == id).FirstOrDefaultAsync();

        public async Task<List<ParkingLot>> GetParkingLotPartial(int pageSize, int pageIndex)
        {
            var parkingLots = _parkingLotCollection.Find(_ => true).ToList();
            var pagedParkingLots = parkingLots.Skip((pageIndex) * pageSize).Take(pageSize).ToList();
            return pagedParkingLots;
        }

        public async Task<ParkingLot> UpdateParkingLot(string id, ParkingLot parkingLot)
        {
            var candidate = await _parkingLotCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
            if (parkingLot.Name != null) candidate.Name = parkingLot.Name;
            if (parkingLot.Capacity != 0) candidate.Capacity = parkingLot.Capacity;
            if (parkingLot.Location != null) candidate.Location = parkingLot.Location;
            await _parkingLotCollection.ReplaceOneAsync(a => a.Id == id, candidate);
            return candidate;
        }
    }
}
