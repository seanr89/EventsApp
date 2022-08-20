
using AutoMapper;
using EventsAPI.DTOs;
using EventsAPI.Models;

namespace EventsAPI.Profiles;

public class AttendeeProfile : Profile
{
    public AttendeeProfile()
    {   
        CreateMap<CreateAttendeeDTO, Attendee>();
            //.AfterMap((src, dest) => dest.AttendedEvent.Id = src.AttendedEventId);
            //.ForMember(dest =>  dest.AttendedEvent.Id, opt => opt.MapFrom(src => src.AttendedEventId));
        CreateMap<Attendee, AttendeeDTO>();
    }
}