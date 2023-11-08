using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
