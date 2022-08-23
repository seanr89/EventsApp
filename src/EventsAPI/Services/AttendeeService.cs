
using AutoMapper;
using EventsAPI.Context;
using EventsAPI.DTOs;
using EventsAPI.Models;
using EventsAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Services;

/// <summary>
/// Dedicated service to move events db work away from controller!
/// </summary>
public class AttendeeService : IAttendeeService
{
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<AttendeeService> _logger;
    public AttendeeService(ApplicationContext context, IMapper mapper,
        ILogger<AttendeeService> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IEnumerable<Attendee>> GetAllAttendees()
    {
        return await _context.Attendees.ToListAsync();
    }

    public async Task<Attendee> GetAttendeeById(Guid id)
    {
        return await _context.Attendees.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<bool> SaveAttendee(Attendee attendeeDTO)
    {
        try{
            await _context.AddAsync(attendeeDTO);
            var res = await _context.SaveChangesAsync();
            if(res > 0)
                return true;
            return false;
        }
        catch(Exception e)
        {
            _logger.LogError($"SaveAttendee: Exception caught: {e.Message}");
            return false;
        }

    }
}