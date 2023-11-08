﻿using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Xml.Linq;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using ParkingLotApi.Dtos;
using ParkingLotApi.Models;
using ParkingLotApi.Repositories.Interface;

namespace ParkingLotApi.Repositories
{
    public class ParkingLotRepository : IParkingLotRepository
    {

        private readonly IMongoCollection<ParkingLot> _parkingLotCollection;

        public ParkingLotRepository(IOptions<ParkingLotDataBaseSetting> parkingLotDataBaseSetting)
        {
            var mongoClient = new MongoClient(parkingLotDataBaseSetting.Value.ConnectionStrings);
            var mongoDatabase = mongoClient.GetDatabase(parkingLotDataBaseSetting.Value.DatabaseName);
            _parkingLotCollection = mongoDatabase.GetCollection<ParkingLot>(parkingLotDataBaseSetting.Value.CollectionName);
        }

        public async Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot)
        {
            await _parkingLotCollection.InsertOneAsync(parkingLot);
            return await GetByName(parkingLot.Name);

        }

        public async Task DeleteById(string id)
        {
            await _parkingLotCollection.DeleteOneAsync(a => a.Id == id);
        }

        public async Task<List<ParkingLot>> GetAll(int? pageIndex, int? pageSize)
        {
            var skip = (pageIndex - 1) * pageSize;
            var query = _parkingLotCollection.Find(a => true);
            var parkinglots = await query.Skip(skip).Limit(pageSize).ToListAsync();
            return parkinglots;
        }

        public async Task<ParkingLot> GetById(string id)
        {
             return await _parkingLotCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ParkingLot> GetByName(string name)
        {
            return  await _parkingLotCollection.Find(a => a.Name == name).FirstOrDefaultAsync();

        }

        public async Task<ParkingLot> Update(string id, ParkingLot parkingLot)
        {
            parkingLot.Id = id;
            await _parkingLotCollection.ReplaceOneAsync(a => a.Id == id, parkingLot);
            return parkingLot;
        }
    }
}