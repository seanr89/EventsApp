using EventsAPI.Context;
using EventsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
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

    /// <summary>
    /// Support querying of all Events from DB
    /// </summary>
    /// <returns></returns>
    [ProducesResponseType(typeof(IEnumerable<Event>),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var rec = await _context.Events.ToListAsync();
        if(rec != null)
            return Ok(rec);
            
        return BadRequest();
    }

    /// <summary>
    /// Support the querying of a single Event by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [ProducesResponseType(typeof(Event),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var rec = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);

        if(rec != null)
            return Ok(rec);
        
        return BadRequest();
    }

    /// <summary>
    /// Validate and Save a new Event to DB
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Post([FromBody] Event type)
    {
        throw new NotImplementedException();
    }
}