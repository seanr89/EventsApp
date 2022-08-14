using AutoMapper;
using EventsAPI.Context;
using EventsAPI.DTOs;
using EventsAPI.Models;
using EventsAPI.Models.Settings;
using EventsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EventsAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AttendeeController : ControllerBase
{
    private readonly ILogger<AttendeeController> _logger;
    private readonly IAttendeeService _attendeeService;
    private readonly IMapper _mapper;

    public AttendeeController(ILogger<AttendeeController> logger,
        IAttendeeService attendeeService, IMapper mapper)
    {
        _logger = logger;
        _attendeeService = attendeeService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<AttendeeDTO>),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        _logger.LogInformation("Attendee:Get");
        var rec = await _attendeeService.GetAllAttendees();
        if(rec.Any())
            return Ok(_mapper.Map<IEnumerable<AttendeeDTO>>(rec));
            
        return BadRequest();
    }

    /// <summary>
    /// Add a single attendee and assign to an event
    /// </summary>
    /// <param name="attendee"></param>
    /// <returns></returns>
    [HttpPost(Name = "AddAttendee")]
    [ProducesResponseType(typeof(IEnumerable<EventDTO>),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Post(CreateAttendeeDTO attendee)
    {
        throw new NotImplementedException();
    }
}