using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using ParkingLotApi.DTOs;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Interfaces;

namespace ParkingLotApi.Repositories
{
    public class ParkingLotRepository : IParkingLotRepository
    {
        private readonly IMongoCollection<ParkingLotEntity> collection;

        public ParkingLotRepository(IOptions<DatabaseSettings> dbOptions)
        {
            var client = new MongoClient(dbOptions.Value.ConnectionString);
            var mongoDB = client.GetDatabase(dbOptions.Value.DatabaseName);
            collection = mongoDB.GetCollection<ParkingLotEntity>(dbOptions.Value.CollectionName);
        }
        public async Task<ParkingLotEntity> AddOneAsync(ParkingLotEntity parkingLotDto)
        {
            if (parkingLotDto.Id == null || !ObjectId.TryParse(parkingLotDto.Id, out var _))
            {
                parkingLotDto.Id = ObjectId.GenerateNewId().ToString();
            }

            await collection.InsertOneAsync(parkingLotDto);
            return parkingLotDto;
        }

        public async Task<ParkingLotEntity> GetByIdAsync(string id)
        {
            if (!ObjectId.TryParse(id, out var _))
            {
                return null;
            }

            var item = await collection.FindAsync(a => a.Id == id);
            return await item.FirstOrDefaultAsync();
        }

        public async Task<ParkingLotEntity> GetByNameAsync(string name)
        {

            var item = await collection.FindAsync(a => a.Name == name);
            return await item.FirstOrDefaultAsync();
        }

        public async Task<List<ParkingLotEntity>> GetAllAsync()
        {
            var items = await collection.FindAsync(_ => true);
            return items.ToList();
        }

        public async Task<long> DeleteByIdAsync(string id)
        {
            var result = await collection.DeleteOneAsync(item => item.Id == id);
            return result.DeletedCount;
        }

        public async Task<ParkingLotEntity> UpdateByIdAsync(ParkingLotEntity parkingLotDto)
        {
            var res = await collection.ReplaceOneAsync(u => u.Id == parkingLotDto.Id, parkingLotDto);
            if (res.MatchedCount > 0)
            {
                var newUser = await collection.FindAsync(u => u.Id == parkingLotDto.Id);
                return await newUser.FirstOrDefaultAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task<List<ParkingLotEntity>> GetByPageIndexAndPageSizeAsync(int pageIndex, int pageSize)
        {
            return await collection.Find(_ => true).Skip(pageSize * (pageIndex - 1)).Limit(pageSize).ToListAsync();
        }
    }
}
