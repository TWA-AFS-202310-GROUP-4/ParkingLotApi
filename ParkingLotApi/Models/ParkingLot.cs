namespace ParkingLotApi.Models
{
    public class ParkingLot
    {

        private string name;

        private string location;

        private int capacity;
        public string Name { get; set; }

        public string Location { get { return location; } set { location = value; } }
        public int Capacity { get { return capacity; } set { capacity = value; } }
    
    }
}
