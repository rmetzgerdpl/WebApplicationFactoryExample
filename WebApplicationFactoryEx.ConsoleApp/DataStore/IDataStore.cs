using WebApplicationFactoryEx.ConsoleApp.Accessors;

namespace WebApplicationFactoryEx.ConsoleApp.DataStore
{
    public interface IDataStore
    {
        public IWeatherAccessor weatherAccessor {get; }
    }
}