
using AutoMapper;
using EventsAPI.DTOs;
using EventsAPI.Models;

namespace EventsAPI.Profiles;

public class EventProfile : Profile
{
    public EventProfile()
    {   
        CreateMap<CreateEventDTO, Event>();
        CreateMap<Event, EventDTO>();
    }
}