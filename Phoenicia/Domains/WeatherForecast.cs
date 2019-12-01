using System;

namespace Phoenicia.Domains
{
    public class WeatherForecast
    {
        public WeatherForecast()
        {
        }

        public WeatherForecast(int temperatureC, string summary) : this()
        {
            TemperatureC = temperatureC;
            Summary = summary;
        }

        public WeatherForecast(DateTime date, int temperature, string summary) : this(temperature, summary)
        {
            Date = date;
        }

        public virtual long Id { get; protected set; }

        public virtual DateTime Date { get; protected set; } = DateTime.UtcNow;

        public virtual int TemperatureC { get; protected set; }

        public virtual int TemperatureF => 32 + (int) (TemperatureC / 0.5556);

        public virtual string Summary { get; protected set; }
    }
}