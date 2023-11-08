using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ParkingLotApi.Models
{
    public class ParkingLot
    {
        public ParkingLot() { }

        public ParkingLot(string name, int capacity, string location)
        {
            Name = name;
            Capacity = capacity;
            Location = location;
        }


        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public int Capacity { get; set; } = 10;
        public string? Location { get; set; }
    }
}