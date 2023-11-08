using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Models;
using ParkingLotApi.Exceptions;
using System.Security.Claims;

namespace ParkingLotApi.Repositories;

public class ParkingLotsRepository : IParkingLotsRepository
{
    private const int PageSize = 15;
    private readonly IMongoCollection<ParkingLot> _parkingLotColelction;

    public ParkingLotsRepository(IOptions<ParkingLotDatabaseSetting> parkingLotDataBaseSetting)
    {
        var mongoClient = new MongoClient(parkingLotDataBaseSetting.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(parkingLotDataBaseSetting.Value.DatabaseName);
        _parkingLotColelction = mongoDatabase.GetCollection<ParkingLot>(parkingLotDataBaseSetting.Value.CollectionName);
    }

    public async Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot)
    {
        await _parkingLotColelction.InsertOneAsync(parkingLot);
        return  _parkingLotColelction.Find(lot => lot.Name.Equals(parkingLot.Name)).FirstOrDefault();
    }

    public async Task DeleteAParkingLot(string id)
    {
        var result = await _parkingLotColelction.DeleteOneAsync(lot => lot.Id.Equals(id));

        if (result.DeletedCount != 1)
        {
            throw new ParkingLotNotFoundException();
        }
    }

    public async Task<List<ParkingLot>> GetParkingLots(int pageNumber)
    {
        return await _parkingLotColelction.Find(_ => true).Skip((pageNumber - 1) * PageSize).Limit(PageSize).ToListAsync();
    }

    public async Task<ParkingLot> GetParkingLotById(string id)
    {

        var filter = Builders<ParkingLot>.Filter.Where(lot => lot.Id.Equals(id));
        var result = await _parkingLotColelction.FindAsync(filter);
        var targetLot = result.FirstOrDefault();

        if (targetLot == null) 
        {
            throw new ParkingLotNotFoundException();
        }

        return targetLot;
    }

    public async Task<ParkingLot> UpdateCapacity(string id, int capacity)
    {
        var filter = Builders<ParkingLot>.Filter.Where(lot => lot.Id.Equals(id));
        var update = Builders<ParkingLot>.Update.Set(lot => lot.Capacity, capacity);
        var result = await _parkingLotColelction.UpdateOneAsync(filter, update);

        if (result.ModifiedCount != 1)
        {
            throw new ParkingLotNotFoundException();
        }

        return _parkingLotColelction.Find(lot => lot.Id.Equals(id)).FirstOrDefault();
    }
}
