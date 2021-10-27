using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Server.Domain;

namespace Server.Application.Services.DataTransfer.MappingProfiles
{
    public class ShipmentStateMappingProfile: Profile
    {
        public ShipmentStateMappingProfile()
        {
            CreateMap<ShipmentState, ShipmentStateData>().ForMember(dto => dto.CurrentState, src => src.MapFrom(src => src.CurrentState));
            CreateMap<ShipmentState, ShipmentStateData>().ForMember(dto => dto.FromDate, src => src.MapFrom(src => src.FromDate));
            CreateMap<ShipmentState, ShipmentStateData>().ForMember(dto => dto.ToDate, src => src.MapFrom(src => src.ToDate));
        }
    }
}
