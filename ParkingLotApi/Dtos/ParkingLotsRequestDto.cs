namespace ParkingLotApi.Dtos;

public class ParkingLotsRequestDto
{
    public string Name {  get; set; }
    
    public string Location { get; set; }

    public int Capacity { get; set; }
}
