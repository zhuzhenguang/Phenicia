using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using Phoenicia.Domains;
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
            List<WeatherForecast> weatherForecasts = Scope.GetService<ISession>().Query<WeatherForecast>().ToList();
            Assert.Single(weatherForecasts);
            Assert.True(weatherForecasts.Single().Id > 0);
            Assert.Equal(20, weatherForecasts.Single().TemperatureC);
            Assert.Equal(67, weatherForecasts.Single().TemperatureF);
            Assert.Equal("hello, this is temperature", weatherForecasts.Single().Summary);
            Assert.NotEqual(default, weatherForecasts.Single().Date);
        }
    }
}