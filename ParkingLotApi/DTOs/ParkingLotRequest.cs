namespace ParkingLotApi.DTOs
{
    public class ParkingLotRequest
    {
        public ParkingLotRequest()
        {
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
    }
}