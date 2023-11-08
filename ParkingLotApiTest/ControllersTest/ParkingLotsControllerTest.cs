using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using ParkingLotApi.Request;
using System.Net.Http.Json;
using ParkingLotApi.Models;
using ParkingLotApi.Repository;
using Moq;

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
            var mock = new Mock<IParkingLotsRepository>();
            mock.Setup(repository=>repository.AddParkingLotAsync(It.IsAny<ParkingLot>())).Returns((ParkingLot fakeLot)=>Task.FromResult(fakeLot));
            var client = GetClient(mock.Object);
            var parkingLotRequest = prepareParkingLotRequest();
            var fakeParkingLot = new ParkingLot(parkingLotRequest.Name, (int)parkingLotRequest.Capacity, parkingLotRequest.Location);
            fakeParkingLot.Id = "123";

            //when
            var createParkingLotResponse = await client.PostAsJsonAsync("/ParkingLots", fakeParkingLot);

            //then
            mock.Verify(repository=>repository.AddParkingLotAsync(It.IsAny<ParkingLot>()),Times.Once());
            Assert.Equal(HttpStatusCode.Created,createParkingLotResponse.StatusCode);
        }

        //[Fact]
        //public async Task should_created_parkingLot_with_Id_when_createParkingLot()
        //{
        //    //given
        //    var request = prepareParkingLotRequest();

        //    //when
        //    HttpResponseMessage httpResponseMessage = await GetClient().PostAsJsonAsync("/ParkingLots", request);

        //    //then
        //    ParkingLot? parkingLot = await httpResponseMessage.Content.ReadFromJsonAsync<ParkingLot>();
        //    Assert.NotNull(parkingLot);
        //}

        //[Fact]
        //public async Task should_return_badrequest_when_createParkingLot_given_request_capacity_9()
        //{
        //    //given
        //    var request = prepareParkingLotRequest();
        //    request.Capacity = 9;
        //    //when
        //    HttpResponseMessage httpResponseMessage = await GetClient().PostAsJsonAsync("/ParkingLots", request);

        //    //then
        //    ParkingLot? parkingLot = await httpResponseMessage.Content.ReadFromJsonAsync<ParkingLot>();
        //    Assert.NotNull(parkingLot);
        //}

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
