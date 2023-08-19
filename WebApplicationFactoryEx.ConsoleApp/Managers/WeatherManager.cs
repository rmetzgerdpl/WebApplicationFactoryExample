using WebApplicationFactoryEx.ConsoleApp.DataStore;
using WebApplicationFactoryEx.ConsoleApp.DTO;

namespace WebApplicationFactoryEx.ConsoleApp.Managers
{
    public class WeatherManager : IWeatherManager
    {
        private IDataStore _store;

        public WeatherManager(IDataStore dataStore)
        {
            _store = dataStore;
        }

        public List<WeatherForecast> GetWeatherReport(int days)
        {
            return _store.weatherAccessor.GetWeatherReport(days);
        }
    }
}