using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ParkingLotApiTest.Controller;

public class WeatherForecastControllerTest :TestBase
{
    public WeatherForecastControllerTest(WebApplicationFactory<Program> factory) : base(factory)
    {
    
    }

    [Fact]
    public async Task Should_return_correctly_when_get_weather_forcast()
    {

        HttpClient _httpClient = GetClient();
        //given & when
        HttpResponseMessage response = await _httpClient.GetAsync("/WeatherForecast");

        //then
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
