using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Server.Domain;
namespace Server.Application.Services.DataTransfer.MappingProfiles
{
    public class UserMappingProfile: Profile
    {
        public UserMappingProfile()
        {
   
            CreateMap<User, UserData>().ForMember(dto => dto.Id, src => src.MapFrom(src => src.Id));
            CreateMap<User, UserData>().ForMember(dto => dto.Username, src => src.MapFrom(src => src.UserName));
            CreateMap<User, UserData>().ForMember(dto => dto.Password, src => src.MapFrom(src => src.Password));
            CreateMap<User, UserData>().ForMember(dto => dto.ProfileInfo, src => src.MapFrom(src => src.ProfileInfo));
            CreateMap<User, UserData>().ForMember(dto => dto.UserState, src => src.MapFrom(src => src.UserState));
        }
    }
}
