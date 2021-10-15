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
            CreateMap<User, UserData>();
            CreateMap<UserData, User>();
        }
    }
}
