using EventsAPI.Context;
using EventsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController : ControllerBase
{
    private readonly ILogger<EventController> _logger;
    private readonly ApplicationContext _context;

    public EventController(ILogger<EventController> logger,
        ApplicationContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _context.Events.ToListAsync());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Event type)
    {
        throw new NotImplementedException();
    }
}