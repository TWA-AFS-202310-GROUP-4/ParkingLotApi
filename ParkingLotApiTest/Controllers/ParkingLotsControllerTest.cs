using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi;
using ParkingLotApi.DTOs;

namespace ParkingLotApiTest.Controllers
{
    public class ParkingLotsControllerTest : TestBase
    {
        public ParkingLotsControllerTest(WebApplicationFactory<Program> webApplicationFactory) : base(webApplicationFactory)
        {
        }

        [Fact]
        public async Task Should_return_bad_request_correctly_when_post_given_capacity_less_10()
        {
            //given 
            HttpClient _httpClient = GetClient();
            ParkingLotDTO parkinglotDtoWithCapacity1 = new ParkingLotDTO()
            {
                Name = "name",
                Capacity = 1,
                Location = "S",
            };

            //when
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/parkinglots", parkinglotDtoWithCapacity1);

            //then
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
