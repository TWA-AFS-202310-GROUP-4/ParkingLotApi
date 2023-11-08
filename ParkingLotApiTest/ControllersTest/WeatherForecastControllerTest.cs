using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace ParkingLotApiTest.ControllersTest
{
    public class WeatherForecastControllerTest:TestBase
    {
        public WeatherForecastControllerTest(WebApplicationFactory<Program> factory):base(factory)
        {
        }

        [Fact]
        public async Task should_return_correctly_when_getWeatherForecast()
        {
            //given & when
            HttpResponseMessage httpResponseMessage= await GetClient().GetAsync("WeatherForecast");

            Assert.Equal(HttpStatusCode.OK,httpResponseMessage.StatusCode);
        }
    }
}
