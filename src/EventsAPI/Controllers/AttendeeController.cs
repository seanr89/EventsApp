using EventsAPI.Context;
using EventsAPI.Models.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EventsAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AttendeeController : ControllerBase
{
    private readonly ILogger<AttendeeController> _logger;
    private readonly ApplicationContext _context;

    public AttendeeController(ILogger<AttendeeController> logger,
        ApplicationContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Attendee:Get");
        return Ok("Not Yet Configured!");
    }
}