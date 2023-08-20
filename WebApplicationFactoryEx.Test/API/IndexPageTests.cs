using Xunit;

namespace WebApplicationFactoryEx.API
{
    public class IndexPageTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Program> _factory;

        public IndexPageTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async void HappyPath()
        {
            var response = await _client.GetAsync("/WeatherForecast");

            response.EnsureSuccessStatusCode();
        }
    }
}

