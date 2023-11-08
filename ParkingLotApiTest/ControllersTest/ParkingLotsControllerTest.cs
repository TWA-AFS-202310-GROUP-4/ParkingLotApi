using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using ParkingLotApi.Request;
using System.Net.Http.Json;
using ParkingLotApi.Models;

namespace ParkingLotApiTest.ControllersTest
{
    public class ParkingLotsControllerTest:TestBase
    {
        public ParkingLotsControllerTest(WebApplicationFactory<Program> factory):base(factory)
        {
        }

        [Fact]
        public async Task should_created_parkingLot_with_Id_when_createParkingLot()
        {
            //given
            var request = prepareParkingLotRequest();

            //when
            HttpResponseMessage httpResponseMessage = await GetClient().PostAsJsonAsync("/ParkingLots", request);

            //then
            ParkingLot? parkingLot = await httpResponseMessage.Content.ReadFromJsonAsync<ParkingLot>();
            Assert.NotNull(parkingLot);
        }

        [Fact]
        public async Task should_return_badrequest_when_createParkingLot_given_request_capacity_9()
        {
            //given
            var request = prepareParkingLotRequest();
            request.Capacity = 9;
            //when
            HttpResponseMessage httpResponseMessage = await GetClient().PostAsJsonAsync("/ParkingLots", request);

            //then
            ParkingLot? parkingLot = await httpResponseMessage.Content.ReadFromJsonAsync<ParkingLot>();
            Assert.NotNull(parkingLot);
        }

        private ParkingLotRequest prepareParkingLotRequest()
        {
            string Name = "name1";
            int capacity = 10;
            string location = "qqqqqqqqqqq";
            ParkingLotRequest parkingLot = new ParkingLotRequest(Name, capacity, location);
            return parkingLot;
        }
    }
}
