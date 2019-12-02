using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Phoenicia.Interfaces;
using Phoenicia.Test.Base;
using Xunit;

namespace Phoenicia.Test
{
    public class ApiTest : BaseTest
    {
        [Fact]
        public async Task should_return_weather_forecast()
        {
            HttpClient httpClient = Factory.CreateClient();

            HttpResponseMessage responseMessage = await httpClient.GetAsync("weatherforecast");

            Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        [Fact]
        public async Task should_create_weather_forecast()
        {
            HttpClient httpClient = Factory.CreateClient();

            var request = new WeatherForecastRequest
            {
                Temperature = 20,
                Summary = "hello, this is temperature"
            };
            HttpResponseMessage responseMessage = await httpClient.PostAsync("weatherforecast", request);

            Assert.Equal(HttpStatusCode.Created, responseMessage.StatusCode);
        }
    }
}