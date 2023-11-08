using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi.Dtos;
using System.Net;
using System.Net.Http.Json;

namespace ParkingLotApiTest.Controller;

public class ParkingLotsControllerTest : TestBase
{
    public ParkingLotsControllerTest(WebApplicationFactory<Program> factory) : base(factory)
    {

    }

    [Fact]
    public async Task Should_return_bad_request_when_add_parking_lot_given_capacity_less_then_10()
    {
        //Given
        HttpClient _httpClient = GetClient();
        ParkingLotsDto parkingLotCapacityLess10 = new ParkingLotsDto() {Name = "Test Street", Location = "My Street", Capacity  = 8};

        //When
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/parkinglots", parkingLotCapacityLess10);

        //then
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
