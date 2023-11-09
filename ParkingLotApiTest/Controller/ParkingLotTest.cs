using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi.Dtos;

namespace ParkingLotApiTest.Controller
{
    public class ParkingLotTest : TestBase
    {
        public ParkingLotTest(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task should_return_400_when_create_when_capacity_lessthan_10()
        {
            // Given
            var client = GetClient();
            var data = new ParkingLotDto()
            {
                Name = "Test",
                Capacity = 1,
                Location = "hh"
            };
            
            var response = await client.PostAsJsonAsync("/ParkingLot", data);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
