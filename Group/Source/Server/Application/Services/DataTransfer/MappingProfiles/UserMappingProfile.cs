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
            CreateMap<User, UserData>().ForMember(dto => dto.DisplayName, src => src.MapFrom(src => src.ProfileInfo.DisplayName));
            CreateMap<User, UserData>().ForMember(dto => dto.Email, src => src.MapFrom(src => src.ProfileInfo.EmailAddress));
            CreateMap<User, UserData>().ForMember(dto => dto.Id, src => src.MapFrom(src => src.Id));
            CreateMap<User, UserData>().ForMember(dto => dto.Password, src => src.MapFrom(src => src.Password));
            CreateMap<User, UserData>().ForMember(dto => dto.PhoneNumber, src => src.MapFrom(src => src.ProfileInfo.PhoneNumber));
            CreateMap<User, UserData>().ForMember(dto => dto.Username, src => src.MapFrom(src => src.UserName));

            CreateMap<UserData, User>().ForMember(dto => dto.ProfileInfo.DisplayName, src => src.MapFrom(src => src.DisplayName));
            CreateMap<UserData, User>().ForMember(dto => dto.ProfileInfo.EmailAddress, src => src.MapFrom(src => src.Email));
            CreateMap<UserData, User>().ForMember(dto => dto.Id, src => src.MapFrom(src => src.Id));
            CreateMap<UserData, User>().ForMember(dto => dto.Password, src => src.MapFrom(src => src.Password));
            CreateMap<UserData, User>().ForMember(dto => dto.ProfileInfo.PhoneNumber, src => src.MapFrom(src => src.PhoneNumber));
            CreateMap<UserData, User>().ForMember(dto => dto.UserName, src => src.MapFrom(src => src.Username));
        }
    }
}
