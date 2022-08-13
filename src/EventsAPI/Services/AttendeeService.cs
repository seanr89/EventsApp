
using AutoMapper;
using EventsAPI.Context;
using EventsAPI.Models;
using EventsAPI.Services.Interfaces;

namespace EventsAPI.Services;

/// <summary>
/// Dedicated service to move events db work away from controller!
/// </summary>
public class AttendeeService : IAttendeeService
{
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;
    public AttendeeService(ApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<IEnumerable<Attendee>> GetAllAttendees()
    {
        throw new NotImplementedException();
    }

    public Task<Attendee> GetAttendeeById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveEvent(Attendee evnt)
    {
        throw new NotImplementedException();
    }
}