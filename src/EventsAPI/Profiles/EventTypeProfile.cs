
using AutoMapper;
using EventsAPI.DTOs;
using EventsAPI.Models;

namespace EventsAPI.Profiles;

public class EventTypeProfile : Profile
{
    public EventTypeProfile()
    {   
        // CreateMap<CreateEventDTO, Event>();
        CreateMap<EventType, EventTypeDTO>();
    }
}