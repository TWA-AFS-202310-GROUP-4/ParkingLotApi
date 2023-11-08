using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Models;
using ParkingLotApi.Request;

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

        public async Task<ParkingLot> AddParkingLot(ParkingLot parkingLotDTO)
        {

            await _parkingLotCollection.InsertOneAsync(parkingLotDTO);
            return await _parkingLotCollection.Find(parkingLot => parkingLot.Name == parkingLotDTO.Name).FirstAsync();
        }

        public async Task<bool> DeleteParkingLotAsync(string id)
        {
            var res = await _parkingLotCollection.DeleteOneAsync(parkingLot => parkingLot.Id == id);
            return res.DeletedCount == 0 ? false:true ;
        }

        public async Task<List<ParkingLot>> GetParkingLotByPageIndexAsync(int? pageIndex)
        {
            return await _parkingLotCollection.Find(Builders<ParkingLot>.Filter.Empty).Skip((pageIndex - 1) * _pageSize).Limit(_pageSize).ToListAsync();
        }

        public async Task<ParkingLot?> GetParkingLotAsync(string id)
        {
            var res = await _parkingLotCollection.Find(parkingLot => parkingLot.Id == id).FirstOrDefaultAsync();
            return res == null ? null : res;
        }
    }
}
