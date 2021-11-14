using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Server.Domain;

namespace Server.Application.Services.DataTransfer.MappingProfiles
{
    public class UserStateMappingProfile: Profile
    {
        public UserStateMappingProfile()
        {
            CreateMap<UserState, UserStateData>().ForMember(dto => dto.Date, src => src.MapFrom(src => src.Date));
            CreateMap<UserState, UserStateData>().ForMember(dto => dto.Type, src => src.MapFrom(src => src.Status));
        }
    }
}
