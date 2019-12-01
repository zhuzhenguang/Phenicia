using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using Phoenicia.Domains;

namespace Phoenicia.Interfaces
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ISession session;

        public WeatherForecastController(ISession session)
        {
            this.session = session;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                (
                    DateTime.Now.AddDays(index),
                    rng.Next(-20, 55),
                    Summaries[rng.Next(Summaries.Length)]
                ))
                .ToArray();
        }

        [HttpPost]
        public ActionResult Create(WeatherForecastRequest request)
        {
            var weatherForecast = new WeatherForecast(request.Temperature, request.Summary);
            using (var transaction = session.BeginTransaction())
            {
                session.Save(weatherForecast);
                transaction.Commit();
            }

            return Created("weatherforecast", null);
        }
    }
}