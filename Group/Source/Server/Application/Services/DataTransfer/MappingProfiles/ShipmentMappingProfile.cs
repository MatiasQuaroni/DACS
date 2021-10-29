using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Server.Domain;

namespace Server.Application.Services.DataTransfer.MappingProfiles
{
    public class ShipmentMappingProfile: Profile
    {
        public ShipmentMappingProfile()
        {
            CreateMap<Shipment, ShipmentData>().ForMember(dto => dto.ArrivalDate, src => src.MapFrom(src => src.ArrivalDate));
            CreateMap<Shipment, ShipmentData>().ForMember(dto => dto.Customer, src => src.MapFrom(src => src.Customer));
            CreateMap<Shipment, ShipmentData>().ForMember(dto => dto.EstimatedArrivalDate, src => src.MapFrom(src => src.EstimatedArrivalDate));
            CreateMap<Shipment, ShipmentData>().ForMember(dto => dto.Id, src => src.MapFrom(src => src.Id));
            CreateMap<Shipment, ShipmentData>().ForMember(dto => dto.DestinationAddress, src => src.MapFrom(src => src.DestinationAddress));
            CreateMap<Shipment, ShipmentData>().ForMember(dto => dto.Precautions, src => src.MapFrom(src => src.Precautions));
            CreateMap<Shipment, ShipmentData>().ForMember(dto => dto.Status, src => src.MapFrom(src => src.States));
            CreateMap<Shipment, ShipmentData>().ForMember(dto => dto.Weight, src => src.MapFrom(src => src.Weight));
        }
    }
}
