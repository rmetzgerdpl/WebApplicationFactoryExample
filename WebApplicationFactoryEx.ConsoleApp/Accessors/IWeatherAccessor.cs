using WebApplicationFactoryEx.ConsoleApp.DTO;

namespace WebApplicationFactoryEx.ConsoleApp.Accessors
{
    public interface IWeatherAccessor
    {
        public List<WeatherForecast> GetWeatherReport(int days);
    }
}