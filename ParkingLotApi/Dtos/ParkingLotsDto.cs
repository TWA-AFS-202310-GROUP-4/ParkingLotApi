using ParkingLotApi.Models;

namespace ParkingLotApi.Dtos;

public class ParkingLotsDto
{
    public string Name {  get; set; }
    
    public string Location { get; set; }

    public int Capacity { get; set; }

    internal ParkingLot ToEntity()
    {
        return new ParkingLot()
        {
            Capacity = Capacity,
            Name = Name,
            Location = Location,
        };
    }

}
