using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest.Controllers
{
    public class ParkingLotsControllerTest : TestBase
    {
        public ParkingLotsControllerTest(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async void Should_return_400_When_post_parkinglots_given_capacity_less_10()
        {
            var parkingLot = new ParkingLotDtoRequest()
            {
                Name = "test",
                Capacity = 9,
                Location = "test loc",
            };
            var client = GetClient();

            var response = await client.PostAsJsonAsync("/parkinglots", parkingLot);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
