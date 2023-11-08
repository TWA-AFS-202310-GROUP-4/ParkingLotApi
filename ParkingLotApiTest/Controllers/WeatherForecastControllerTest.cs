using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest.Controllers
{
    public class WeatherForecastControllerTest
    {
        private HttpClient _httpClient;

        public WeatherForecastControllerTest()
        {
            WebApplicationFactory<Program> factory = new WebApplicationFactory<Program>();
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task Should_return_correctly_when_get_weather_forecast()
        {
            // given & when
            var response = await _httpClient.GetAsync("/weatherforecast");

            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}
