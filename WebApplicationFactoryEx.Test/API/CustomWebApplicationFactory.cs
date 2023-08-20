using WebApplicationFactoryEx.ConsoleApp.DataStore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplicationFactoryEx.API
{
    public class CustomWebApplicationFactory<TProgram> :
        WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddDbContext<DbContext>(options =>
                {
                    //From Microsoft.EntityFrameworkCore.InMemory library
                    options.UseInMemoryDatabase("InMemoryDb");
                    // Don't raise error about InMemory not supporting transactions
                    options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                });

                services.AddScoped<IDataStore, WeatherDataStoreInMemory>();
            });
        }
    }
}
