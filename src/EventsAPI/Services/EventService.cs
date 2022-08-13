

using AutoMapper;
using EventsAPI.Context;
using EventsAPI.Models;
using EventsAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Services;

/// <summary>
/// Dedicated service to move events db work away from controller!
/// </summary>
public class EventService : IEventService
{
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;
    public EventService(ApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Event>> GetAllEvents()
    {
        return await _context.Events.ToListAsync();
    }

    public async Task<Event> GetEventById(Guid id)
    {
        return await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
    }

    public Task<IEnumerable<Event>> GetEventsForDate(DateOnly date)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveEvent(Event evnt)
    {
        var convertedModel =  _mapper.Map<Event>(evnt);
        var res = await _context.SaveChangesAsync();
        if(res > 0)
        {
            return true;
        }
        return false;
    }
}