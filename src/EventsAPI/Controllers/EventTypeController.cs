using EventsAPI.Context;
using EventsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
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

    /// <summary>
    /// Provides a method to query all events
    /// </summary>
    /// <returns></returns>
    [ProducesResponseType(typeof(IEnumerable<EventType>),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _context.EventTypes.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _context.EventTypes.ToListAsync());
    }

    /// <summary>
    /// provides a method to create a new event
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventType type)
    {
        if (!ModelState.IsValid)
        {
            //_logger.LogError("Invalid owner object sent from client.");
            return BadRequest("Invalid model object");
        }

        var res = await _context.EventTypes.AddAsync(type);
        if(res != null)
            return Created("GetById", type);
        return BadRequest("DB Insert Failed");
    }
}