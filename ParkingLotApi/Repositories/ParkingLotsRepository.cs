using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories;

public class ParkingLotsRepository : IParkingLotsRepository
{

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
}
