using AutoMapper;
using EventsAPI.Context;
using EventsAPI.DTOs;
using EventsAPI.Models;
using EventsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class EventTypeController : ControllerBase
{
    private readonly ILogger<EventTypeController> _logger;
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;
    private readonly IEventTypeService _eventTypeService;

    public EventTypeController(ILogger<EventTypeController> logger,
        IEventTypeService eventTypeService,
        ApplicationContext context,
        IMapper mapper)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _eventTypeService = eventTypeService;
        _mapper = mapper;
    }

    /// <summary>
    /// Query and return a list of all events
    /// </summary>
    /// <returns></returns>
    [ProducesResponseType(typeof(IEnumerable<EventTypeDTO>),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var rec = await _context.EventTypes.ToListAsync();
        if(rec != null){
            var mapped = _mapper.Map<List<EventTypeDTO>>(rec);
            return Ok(mapped);
        }
        
        return BadRequest();
    }

    /// <summary>
    /// Query a single EventType
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [ProducesResponseType(typeof(EventTypeDTO),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var rec = await _context.EventTypes.FirstOrDefaultAsync(e => e.Id == id);
        if(rec != null){
            var mapped = _mapper.Map<EventTypeDTO>(rec);
            return Ok(mapped);
        }
        
        return BadRequest("No Record");
    }

    /// <summary>
    /// Create a new event type
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventType type)
    {
        if (!ModelState.IsValid){
            return BadRequest("Invalid model object");
        }

        var res = await _eventTypeService.SaveEventType(type);
        if(res)
            return Created("GetById", type);
        return BadRequest("DB Insert Failed");
    }
}