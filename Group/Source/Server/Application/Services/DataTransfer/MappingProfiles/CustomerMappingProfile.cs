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
            CreateMap<CustomerInfo, CustomerData>().ForMember(dto => dto.Id, src => src.MapFrom(src => src.Id));
            CreateMap<CustomerInfo, CustomerData>().ForMember(dto => dto.Dni, src => src.MapFrom(src => src.Dni));
            CreateMap<CustomerInfo, CustomerData>().ForMember(dto => dto.Email, src => src.MapFrom(src => src.Email));
            CreateMap<CustomerInfo, CustomerData>().ForMember(dto => dto.Name, src => src.MapFrom(src => src.Name));
            CreateMap<CustomerInfo, CustomerData>().ForMember(dto => dto.PhoneNumber, src => src.MapFrom(src => src.PhoneNumber));

            CreateMap<CustomerData, CustomerInfo>().ForMember(src => src.Id, dto => dto.MapFrom(dto => dto.Id));
            CreateMap<CustomerData, CustomerInfo>().ForMember(src => src.Dni, dto => dto.MapFrom(dto => dto.Dni));
            CreateMap<CustomerData, CustomerInfo>().ForMember(src => src.Email, dto => dto.MapFrom(dto => dto.Email));
            CreateMap<CustomerData, CustomerInfo>().ForMember(src => src.Name, dto => dto.MapFrom(dto => dto.Name));
            CreateMap<CustomerData, CustomerInfo>().ForMember(src => src.PhoneNumber, dto => dto.MapFrom(dto => dto.PhoneNumber));
        }
    }
}
