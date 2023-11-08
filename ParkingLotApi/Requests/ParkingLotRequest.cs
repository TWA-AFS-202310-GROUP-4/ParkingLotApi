using ParkingLotApi.Models;

namespace ParkingLotApi.Request

{
    public class ParkingLotRequest
    {
        public ParkingLotRequest() { }
        public ParkingLotRequest(string name, int capacity, string location)
        {
            Name = name;
            Capacity = capacity;
            Location = location;
        }

        public string? Name { get; set; }
        public int? Capacity { get; set; }
        public string? Location { get; set; }

        public ParkingLot ToEntity()
        {
            return new ParkingLot(Name,(int)Capacity,Location);
        }
    }
}