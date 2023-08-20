using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebApplicationFactoryEx.ConsoleApp.DataStore;
using WebApplicationFactoryEx.ConsoleApp.Accessors;

namespace WebApplicationFactoryEx
{
    public class WeatherDataStoreInMemory : IDataStore
    {
        public WeatherDataStoreInMemory()
        {
            //In you were using a DataContenxt
            var readonlyBuilder = new DbContextOptionsBuilder();
            readonlyBuilder.UseInMemoryDatabase("SomeFileName"); //Microsoft.EntityFrameworkCore.InMemory
            // Don't raise error about InMemory not supporting transactions
            readonlyBuilder.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            var dbcontext = new DbContext(readonlyBuilder.Options);
                
            repo = new WeatherAccessorInMemory();
        }
        
        private IWeatherAccessor repo;

        public IWeatherAccessor weatherAccessor => repo ?? new WeatherAccessorInMemory();
    }
}