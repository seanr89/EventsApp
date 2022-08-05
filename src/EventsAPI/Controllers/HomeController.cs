using EventsAPI.Context;
using EventsAPI.Models.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EventsAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationContext _context;
    private readonly PostgreSQLSettings _postSettings;
    private readonly IConfiguration _config;

    public HomeController(ILogger<HomeController> logger,
        ApplicationContext context,
        IOptions<PostgreSQLSettings> postSettings,
        IConfiguration config)
    {
        _logger = logger;
        _context = context;
        _postSettings = postSettings.Value;
        _config = config;
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

    [HttpGet(Name = "CheckFile")]
    public IActionResult CheckFile()
    {
        _logger.LogInformation("CheckFile");
        return Ok(_config["File"]);
    }

    [HttpGet(Name = "DbCheck")]
    public IActionResult DbCheck()
    {
        _logger.LogInformation("DbCheck");
        var check = _context.Database.CanConnect();
        return Ok(check);
    }
}