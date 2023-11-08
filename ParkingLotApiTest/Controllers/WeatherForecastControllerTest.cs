using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ParkingLotApiTest.Controllers
{
    public class WeatherForecastControllerTest
    {

        public HttpClient httpClient;
        public WeatherForecastControllerTest()
        {
            WebApplicationFactory<Program> factory = new WebApplicationFactory<Program>();
            httpClient = factory.CreateClient();
        }


        [Fact]
        public async Task Shaould_return_Ok_when_get_WeatherForecast()
        {
         var  responseMessage =  await httpClient.GetAsync("/WeatherForecast");
         Assert.Equal(HttpStatusCode.OK,responseMessage.StatusCode);
        }
    }
}
