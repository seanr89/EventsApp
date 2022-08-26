

using AutoMapper;
using EventsAPI.Context;
using EventsAPI.Models;
using EventsAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Services;

/// <summary>
/// supports event DB integration
/// </summary>
public class EventService : IEventService
{
    private readonly ApplicationContext _context;
    private readonly ILogger<EventService> _logger;
    public EventService(ApplicationContext context, ILogger<EventService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<Event>> GetAllEvents() => await _context.Events.ToListAsync();

    public async Task<Event> GetEventById(Guid id) => await _context.Events.FirstOrDefaultAsync(e => e.Id == id);

    public async Task<IEnumerable<Event>> GetEventsForDate(DateOnly date) => await _context.Events
        .Where(e => DateOnly.FromDateTime(e.Date) == date).ToListAsync();

    public async Task<bool> SaveEvent(Event evnt)
    {
        try{
            await _context.Events.AddAsync(evnt);
            if(await _context.SaveChangesAsync() > 0)
                return true;
            return false;
        }
        catch (System.Exception e){
            _logger.LogError($"SaveEvent: Exception caught: {e.Message}");
            return false;
        }
    }
}