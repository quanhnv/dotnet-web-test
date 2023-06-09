using Microsoft.AspNetCore.Mvc;

namespace DotnetWebTest.Controllers2;

[ApiVersion("2.0")]
[Route("[controller]")]
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

    public async Task<IActionResult> Test(){
        try{
            return Ok();
        }catch(Exception e){
            throw;
        }
    }
    
}
