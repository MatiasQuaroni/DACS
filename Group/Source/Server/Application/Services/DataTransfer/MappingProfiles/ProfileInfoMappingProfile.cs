using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Server.Domain;

namespace Server.Application.Services.DataTransfer.MappingProfiles
{
    public class ProfileInfoMappingProfile: Profile
    {
        public ProfileInfoMappingProfile()
        {
            CreateMap<ProfileInfo, ProfileInfoData>().ForMember(dto => dto.DisplayName, src => src.MapFrom(src => src.DisplayName));
            CreateMap<ProfileInfo, ProfileInfoData>().ForMember(dto => dto.Email, src => src.MapFrom(src => src.EmailAddress));
            CreateMap<ProfileInfo, ProfileInfoData>().ForMember(dto => dto.PhoneNumber, src => src.MapFrom(src => src.PhoneNumber));

        }
    }
}
