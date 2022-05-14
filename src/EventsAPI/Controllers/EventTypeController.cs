using EventsAPI.Context;
using EventsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EventTypeController : ControllerBase
{
    private readonly ILogger<EventTypeController> _logger;
    private readonly ApplicationContext _context;

    public EventTypeController(ILogger<EventTypeController> logger,
        ApplicationContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        //return Ok("This Works");
        return Ok(await _context.EventTypes.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventType type)
    {
        var res = await _context.EventTypes.AddAsync(type);
        return Ok(res);
    }
}