using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi.Dtos;
using ParkingLotApi.Models;

namespace ParkingLotApiTest.Controllers
{
    public class ParkingLotsControllerTest : TestBase
    {

        private HttpClient httpClient;
        public ParkingLotsControllerTest(WebApplicationFactory<Program> factory) : base(factory)
        {
            httpClient = GetClient();
        }

        [Fact]
        public async Task Shaould_return_Ok_when_get_WeatherForecast()
        {
            ParkingLotDto parkingLot = new ParkingLotDto()
            {
                Name = "heihie",
                Capacity = 8,
                Location = "beijing"
            };
            var responseMessage = await httpClient.PostAsJsonAsync("/ParkingLots",parkingLot);
            Assert.Equal(HttpStatusCode.BadRequest, responseMessage.StatusCode);
        }
    }
}
