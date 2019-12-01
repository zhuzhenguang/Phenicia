using FluentNHibernate.Mapping;
using Phoenicia.Domains;

namespace Phoenicia.Infrastructures.Mappings
{
    public class WeatherForecastMapping : ClassMap<WeatherForecast>
    {
        public WeatherForecastMapping()
        {
            Table("weather_forecast");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.TemperatureC);
            Map(x => x.Date);
            Map(x => x.Summary);
        }
    }
}