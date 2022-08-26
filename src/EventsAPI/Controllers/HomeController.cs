using EventsAPI.Context;
using EventsAPI.Models.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EventsAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationContext _context;
    private readonly IConfiguration _config;

    public HomeController(ILogger<HomeController> logger,
        ApplicationContext context,
        IConfiguration config)
    {
        _logger = logger;
        _context = context;
        _config = config;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Home:Get");
        return Ok();
    }

    // [HttpGet(Name = "CheckFile")]
    // public IActionResult CheckFile()
    // {
    //     _logger.LogInformation("CheckFile");
    //     return Ok(_config["File"]);
    // }

    // [HttpGet(Name = "DbCheck")]
    // public IActionResult DbCheck()
    // {
    //     _logger.LogInformation("DbCheck");
    //     var check = _context.Database.CanConnect();
    //     return Ok(check);
    // }
}