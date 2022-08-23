
using AutoMapper;
using EventsAPI.Context;
using EventsAPI.Models;
using EventsAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Services;

/// <summary>
/// Dedicated service to move events db work away from controller!
/// </summary>
public class EventTypeService : IEventTypeService
{
    private readonly ApplicationContext _context;
    private readonly ILogger<EventTypeService> _logger;
    public EventTypeService(ApplicationContext context, ILogger<EventTypeService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<EventType>> GetAllEventTypes() => await _context.EventTypes.ToListAsync();

    public async Task<EventType> GetEventTypeById(int id) => await _context.EventTypes.FirstOrDefaultAsync();
}