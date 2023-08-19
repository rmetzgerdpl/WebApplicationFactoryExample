using WebApplicationFactoryEx.ConsoleApp.DTO;

namespace WebApplicationFactoryEx.ConsoleApp.Managers 
{
    public interface IWeatherManager
    {
        public List<WeatherForecast> GetWeatherReport(int days);
    }
}