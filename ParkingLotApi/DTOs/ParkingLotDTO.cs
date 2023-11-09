using ParkingLotApi.Models;

namespace ParkingLotApi.DTOs
{
    public class ParkingLotDTO
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }

        internal ParkingLot ToEntity()
        {
            return new ParkingLot()
            {
                Name = Name,
                Capacity = Capacity,
                Location = Location
            };
        }
    }
}
