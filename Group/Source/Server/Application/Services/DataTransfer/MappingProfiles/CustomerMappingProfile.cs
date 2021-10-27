using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Server.Domain;

namespace Server.Application.Services.DataTransfer.MappingProfiles
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<CustomerInfo, CustomerData>().ForMember(dto => dto.Dni, src => src.MapFrom(src => src.Dni));
            CreateMap<CustomerInfo, CustomerData>().ForMember(dto => dto.Email, src => src.MapFrom(src => src.Email));
            CreateMap<CustomerInfo, CustomerData>().ForMember(dto => dto.Name, src => src.MapFrom(src => src.Name));
            CreateMap<CustomerInfo, CustomerData>().ForMember(dto => dto.PhoneNumber, src => src.MapFrom(src => src.PhoneNumber));
        }
    }
}
