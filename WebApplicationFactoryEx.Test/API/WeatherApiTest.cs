using Newtonsoft.Json;
using WebApplicationFactoryEx.ConsoleApp.DTO;
using Xunit;

namespace WebApplicationFactoryEx.API
{
    public class WeatherApiTest : IClassFixture<InMemoryApi>, IDisposable
    {
        private InMemoryApi _api;
        private HttpClient client;
        public WeatherApiTest(InMemoryApi api)
        {
            _api = api;
            client = api.CreateAnonymousClient();
        }
        public void Dispose()
        {
            client.Dispose();
        }

        [Fact]
        public async void Weather_Get_HappyPath()
        {
            var results = await client.GetAsync("WeatherForecast");
            string content = await results.Content.ReadAsStringAsync();

            IEnumerable<WeatherForecast> forecasts = JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(content);
            Xunit.Assert.NotEmpty(forecasts);
        }
    }
}