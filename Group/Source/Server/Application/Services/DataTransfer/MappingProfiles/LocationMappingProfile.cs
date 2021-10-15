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
            CreateMap<Location, LocationData>();
            CreateMap<LocationData, Location>();
        }
    }
}
