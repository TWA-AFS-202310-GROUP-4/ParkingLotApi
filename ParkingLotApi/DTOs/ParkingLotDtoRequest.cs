namespace ParkingLotApi.DTOs
{
    public class ParkingLotDtoRequest
    {
        public ParkingLotDtoRequest()
        {
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
    }
}