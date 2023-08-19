using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace WebApplicationFactoryEx.API
{

    public class BasicTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        
        public BasicTests(WebApplicationFactory<Program> factory) {  _factory = factory; }
        
        [Fact]
        public async void HappyPath()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/WeatherForecast");

            response.EnsureSuccessStatusCode();
        }
    }
}