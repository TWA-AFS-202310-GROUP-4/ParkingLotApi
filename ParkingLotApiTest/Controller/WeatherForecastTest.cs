using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace ParkingLotApiTest.Controllers
{
    public class WeatherForecastControllerTest : TestBase
    {
        public WeatherForecastControllerTest(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task should_return_corretly_when_get_wea()
        {
            // Given
            var client = GetClient();
            var response = await client.GetAsync("/WeatherForecast");
            // When
        
            // Then
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}