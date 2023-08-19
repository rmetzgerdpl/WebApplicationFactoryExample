using WebApplicationFactoryEx.ConsoleApp.DTO;

namespace WebApplicationFactoryEx.ConsoleApp.Accessors
{
    public class WeatherAccessor : IWeatherAccessor
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public List<WeatherForecast> GetWeatherReport(int days)
        {
            var rng = new Random();
            return Enumerable.Range(1, days).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index).Date,
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToList<WeatherForecast>();
        }

    }
}