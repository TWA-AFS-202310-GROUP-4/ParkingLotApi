using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ParkingLotApiTest.Controllers
{
    public class WeatherForecastControllerTest : TestBase
    {

        private HttpClient httpClient;
        public WeatherForecastControllerTest(WebApplicationFactory<Program> factory) : base(factory)
        {
            httpClient = GetClient();
        }

        [Fact]
        public async Task Shaould_return_Ok_when_get_WeatherForecast()
        {
            var responseMessage = await httpClient.GetAsync("/WeatherForecast");
            Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
        }
    }
}
