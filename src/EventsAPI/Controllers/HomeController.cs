using EventsAPI.Models.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EventsAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;
    private readonly PostgreSQLSettings _postSettings;

    public HomeController(ILogger<HomeController> logger,
        IOptions<PostgreSQLSettings> postSettings)
    {
        _logger = logger;
        _postSettings = postSettings.Value;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Home:Get");
        return Ok();
    }

    [HttpGet(Name = "GetConnectionSetting")]
    public IActionResult GetConnectionSetting()
    {
        _logger.LogInformation("GetConnectionSetting");
        return Ok(_postSettings.ConnectionString);
    }
}