using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Models;
using ParkingLotApi.Exceptions;

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

    public async Task DeleteParkingLot(string id)
    {
        var result = await _parkingLotColelction.DeleteOneAsync(lot => lot.Id.Equals(id));

        if (result.DeletedCount != 1)
        {
            throw new ParkingLotNotFoundException();
        }
    }
}
