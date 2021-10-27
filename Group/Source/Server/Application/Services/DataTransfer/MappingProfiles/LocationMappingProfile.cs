using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Server.Domain;

namespace Server.Application.Services.DataTransfer.MappingProfiles
{
    public class LocationMappingProfile: Profile
    {
        public LocationMappingProfile()
        {
            CreateMap<Location, LocationData>().ForMember(dto => dto.Address, src => src.MapFrom(src => src.Address));
            CreateMap<Location, LocationData>().ForMember(dto => dto.Floor, src => src.MapFrom(src => src.Floor));
            CreateMap<Location, LocationData>().ForMember(dto => dto.Number, src => src.MapFrom(src => src.Number));
            CreateMap<Location, LocationData>().ForMember(dto => dto.PostalCode, src => src.MapFrom(src => src.PostalCode));

        }
    }
}
