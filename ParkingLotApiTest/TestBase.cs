using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using ParkingLotApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest
{
    public class TestBase : IClassFixture<WebApplicationFactory<Program>>
    {


        public TestBase(WebApplicationFactory<Program> factory)
        {
            Factory = factory;
        }

        protected WebApplicationFactory<Program> Factory { get; }

        protected HttpClient GetClient(IParkingLotsRepository parkingLotsRepository = null)
        {
            return Factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddSingleton<IParkingLotsRepository>(provider =>
                    {
                        return parkingLotsRepository;
                    });
                });
            }).CreateClient();
        }
    }
}
