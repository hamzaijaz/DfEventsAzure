using AutoMapper;
using dfEvents.DataAccess;
using dfEvents.Models;
using System;
using System.Diagnostics.CodeAnalysis;

namespace dfEvents.Mapping
{
    [ExcludeFromCodeCoverage]
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateEventRequest, EventEntity>()
                .ForMember(x => x.EventTitle, opt => opt.MapFrom(src => src.EventTitle))
                .ForMember(x => x.EventDescription, opt => opt.MapFrom(src => src.EventDescription))
                .ForMember(x => x.EventDate, opt => opt.MapFrom(src => src.EventDate))
                .ForMember(x => x.EventType, opt => opt.MapFrom(src => src.EventType))
                .ForMember(x => x.EventCost, opt => opt.MapFrom(src => src.EventCost))
                .ForMember(x => x.Rsvp, opt => opt.MapFrom(I => 0))
                .ForMember(x => x.EventIdentity, opt => opt.MapFrom(I => Guid.NewGuid().ToString()))
                ;



        }
    }
}
