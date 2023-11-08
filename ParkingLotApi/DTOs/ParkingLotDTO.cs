namespace ParkingLotApi.DTO
{
    public class ParkingLotDTO
    {
        ParkingLotDTO() { }

        public ParkingLotDTO(string name, int capacity, string location)
        {
            Id= Guid.NewGuid().ToString();
            Name = name;
            Capacity = capacity;
            Location = location;
        }

        public string? Id { get; set; }
        public string? Name { get; set; }
        public int Capacity { get; set; } = 10;
        public string? Location { get; set; }
    }
}