using AutoMapper;
using EventsAPI.Context;
using EventsAPI.DTOs;
using EventsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class EventController : ControllerBase
{
    private readonly ILogger<EventController> _logger;
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;

    public EventController(ILogger<EventController> logger,
        ApplicationContext context, IMapper mapper)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <summary>
    /// Support querying of all Events from DB
    /// </summary>
    /// <returns></returns>
    [ProducesResponseType(typeof(IEnumerable<EventDTO>),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        _logger.LogInformation("Events:Get");
        var rec = await _context.Events.ToListAsync();
        if(rec.Any())
            return Ok(_mapper.Map<IEnumerable<EventDTO>>(rec));
            
        return BadRequest("No Records");
    }

    /// <summary>
    /// Support the querying of a single Event by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [ProducesResponseType(typeof(DetailedEventDTO),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        _logger.LogInformation("Events:GetById");
        var rec = await _context.Events
            .Include(a => a.Attendees)
            .FirstOrDefaultAsync(e => e.Id == id);

        if(rec != null)
            return Ok(_mapper.Map<DetailedEventDTO>(rec));
        
        return BadRequest("No Record");
    }

    /// <summary>
    /// Validate and Save a new Event to DB
    /// </summary>
    /// <param name="event"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateEventDTO createEvent)
    {
        _logger.LogInformation("Events:Post");
        var convertedModel =  _mapper.Map<Event>(createEvent);
        await _context.Events.AddAsync(convertedModel);
        var res = await _context.SaveChangesAsync();
        if(res > 0)
        {
            return Ok("Saved");
        }
        return BadRequest("Not Saved");
    }
}