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
    private readonly IMapper _mapper;
    private readonly IEventTypeService _eventTypeService;

    public EventTypeController(ILogger<EventTypeController> logger,
        IEventTypeService eventTypeService,
        IMapper mapper)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _eventTypeService = eventTypeService ?? throw new ArgumentNullException(nameof(eventTypeService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
        var rec = await _eventTypeService.GetAllEventTypes();
        if(rec != null)
            return Ok(_mapper.Map<List<EventTypeDTO>>(rec));
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
        var rec = await _eventTypeService.GetEventTypeById(id);
        if(rec != null) 
            Ok(_mapper.Map<EventTypeDTO>(rec));
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
            return BadRequest("Invalid model!");
        }

        var res = await _eventTypeService.SaveEventType(type);
        if(res)
            return Created("GetById", type);
            
        return BadRequest("DB Insert Failed");
    }
}