using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Server.Domain;

namespace Server.Application.Services.DataTransfer.MappingProfiles
{
    public class LegMappingProfile: Profile
    {
        public LegMappingProfile()
        {
            CreateMap<Leg, LegData>().ForMember(dto => dto.Id, src => src.MapFrom(src => src.Id));
            CreateMap<Leg, LegData>().ForMember(dto => dto.StartLocation, src => src.MapFrom(src => src.StartLocation));
            CreateMap<Leg, LegData>().ForMember(dto => dto.EndLocation, src => src.MapFrom(src => src.EndLocation));
        }
    }
}
