
using AutoMapper;
using EventsAPI.Context;
using EventsAPI.Models;
using EventsAPI.Services.Interfaces;

namespace EventsAPI.Services;

/// <summary>
/// Dedicated service to move events db work away from controller!
/// </summary>
public class EventTypeService : IEventTypeService
{
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;
    public EventTypeService(ApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<IEnumerable<EventType>> GetAllEventTypes()
    {
        throw new NotImplementedException();
    }

    public Task<EventType> GetEventTypeById(int id)
    {
        throw new NotImplementedException();
    }
}