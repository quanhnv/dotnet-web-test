using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DotnetWebTest.Controllers;

[Route("api/weather")]
[ApiVersion("1.0")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
    
    [HttpGet("test")]
    [Consumes("application/json", "text/json")]
    [Produces("application/json")]
    [SwaggerParameter("model", "Test bằng attribute ngoài controller")]
    public async Task<IActionResult> Test([FromBody]ApiModel model, [FromBody]ApiModel2 model2){
        return Ok();
    }

    [HttpGet("test-file")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> TestFile([FromForm]FileModel model){
        return Ok();
    }

    [HttpGet("single")]
    [SwaggerParameter("text", "Nhập text vào")]
    [SwaggerOperation(Summary = "Test cái này")]
    public async Task<IActionResult> TestSingleStringAsync(string text)
    {
        return Ok();
    }
}
