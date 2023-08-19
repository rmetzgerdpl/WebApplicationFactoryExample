using WebApplicationFactoryEx.ConsoleApp.Accessors;
using WebApplicationFactoryEx.ConsoleApp.DataStore;

namespace WebApplicationFactoryEx.ConsoleApp.DataStore
{
    public class WeatherDataStore : IDataStore
    {
        public WeatherDataStore()
        {

        }

        private IWeatherAccessor weatherRepo;

        public IWeatherAccessor weatherAccessor => weatherRepo ?? new WeatherAccessor();
    }
}