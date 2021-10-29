using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Server.Domain;

namespace Server.Application.Services.DataTransfer.MappingProfiles
{
    public class ItineraryMappingProfile : Profile
    {
        public ItineraryMappingProfile()
        {
            CreateMap<Itinerary, ItineraryData>().ForMember(dto => dto.StartDate, src => src.MapFrom(src => src.StartDate));
            CreateMap<Itinerary, ItineraryData>().ForMember(dto => dto.EndDate, src => src.MapFrom(src => src.EndDate));
            CreateMap<Itinerary, ItineraryData>().ForMember(dto => dto.Id, src => src.MapFrom(src => src.Id));
            CreateMap<Itinerary, ItineraryData>().ForMember(dto => dto.IsComplete, src => src.MapFrom(src => src.IsComplete));
            CreateMap<Itinerary, ItineraryData>().ForMember(dto => dto.Legs, src => src.MapFrom(src => src.Legs));
            CreateMap<Itinerary, ItineraryData>().ForMember(dto => dto.Shipments, src => src.MapFrom(src => src.Shipments));

            CreateMap<ItineraryData, Itinerary>().ForMember(dto => dto.StartDate, src => src.MapFrom(src => src.StartDate));
            CreateMap<ItineraryData, Itinerary>().ForMember(dto => dto.EndDate, src => src.MapFrom(src => src.EndDate));
            CreateMap<ItineraryData, Itinerary>().ForMember(dto => dto.Id, src => src.MapFrom(src => src.Id));
            CreateMap<ItineraryData, Itinerary>().ForMember(dto => dto.IsComplete, src => src.MapFrom(src => src.IsComplete));
            CreateMap<ItineraryData, Itinerary>().ForMember(dto => dto.Legs, src => src.MapFrom(src => src.Legs));
            CreateMap<ItineraryData, Itinerary>().ForMember(dto => dto.Shipments, src => src.MapFrom(src => src.Shipments));
        }
    }
}
