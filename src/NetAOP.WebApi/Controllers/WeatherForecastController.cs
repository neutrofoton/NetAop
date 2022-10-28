using Microsoft.AspNetCore.Mvc;
using NetAOP.WebApi.Services;

namespace NetAOP.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHelloService helloService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHelloService helloService)
        {
            _logger = logger;
            this.helloService = helloService;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public async Task<IEnumerable<WeatherForecast>> Get()
        //{
        //    string note = null;
        //    //note = this.helloService.Hi();
        //    note = await this.helloService.HiAsync();

        //    var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)],
        //        Note = note
        //    })
        //    .ToArray();

        //    return await Task.FromResult(result);
        //}

        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            string note = this.helloService.Hi();

            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Note = note
            })
            .ToArray();

            return result;
        }

        [HttpGet("GetWeatherForecastAsync")]
        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync()
        {
            string note = await this.helloService.HiAsync();

            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Note = note
            })
            .ToArray();

            return await Task.FromResult(result);
        }
    }
}