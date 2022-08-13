
using AutoMapper;
using EventsAPI.DTOs;
using EventsAPI.Models;

namespace EventsAPI.Profiles;

public class AttendeeProfile : Profile
{
    public AttendeeProfile()
    {   
        CreateMap<CreateAttendeeDTO, Attendee>();
        CreateMap<Attendee, AttendeeDTO>();
    }
}