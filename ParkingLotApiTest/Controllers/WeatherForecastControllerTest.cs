using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ParkingLotApiTest.Controllers
{
    public class WeatherForecastControllerTest:TestBase
    {
        public WeatherForecastControllerTest(WebApplicationFactory<Program> webApplicationFactory):base(webApplicationFactory)
        {
        }

        [Fact]
        public async Task Should_return_correctly_when_get_weather_forcast()
        {
            //given & when
            HttpClient _httpClient = GetClient();
             HttpResponseMessage response= await _httpClient.GetAsync("/WeatherForecast");

            //then
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
