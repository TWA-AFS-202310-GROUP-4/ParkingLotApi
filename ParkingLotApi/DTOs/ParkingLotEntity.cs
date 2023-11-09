using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ParkingLotApi.DTOs
{
    public class ParkingLotEntity
    {
        public ParkingLotEntity()
        {
        }

        public ParkingLotEntity(ParkingLotRequest parkingLotDtoRequest)
        {
            this.Name = parkingLotDtoRequest.Name;
            this.Capacity = parkingLotDtoRequest.Capacity;
            this.Location = parkingLotDtoRequest.Location;
            this.Id = ObjectId.GenerateNewId().ToString();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
    }
}