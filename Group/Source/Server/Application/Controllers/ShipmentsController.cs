using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Domain;
using Server.Application.Services.DataTransfer;
using Server.Application.Services;
using AutoMapper;

namespace Server.Application.Controllers
{
    [Route("Shipments")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        private readonly IShipmentsServices _shipmentsServices;
        private readonly IMapper _mapper;
        public ShipmentsController(IShipmentsServices shipmentsServices, IMapper mapper) 
        { 
            _shipmentsServices = shipmentsServices;
            _mapper = mapper;
        }
        [HttpGet("all")]
        public IList<ShipmentData> GetAllShipments()
        {
            IList<ShipmentData> shipmentsDTOs = new List<ShipmentData>();
            var shipments = _shipmentsServices.GetAllShipments();
            foreach (Shipment s in shipments) 
            {
             shipmentsDTOs.Add(_mapper.Map<ShipmentData>(s));
            }
            return shipmentsDTOs;
        }

        [HttpGet("/byId/{id}")]
        public ShipmentData GetShipment(Guid id)
        {
           return _mapper.Map<ShipmentData>(_shipmentsServices.GetShipment(id));
        }

        [HttpGet("/track/{trackingNumber}")]
        public ShipmentData Track(Guid trackingNumber)
        {
            return _mapper.Map<ShipmentData>(_shipmentsServices.GetShipmentByTrackingNumber(trackingNumber));
        }

        [HttpGet("/byFilter/{filter}")]
        public IList<ShipmentData> GetByFilter(string filter, string searchTerm)
        {
            IList<ShipmentData> shipmentsDTOs = new List<ShipmentData>();
            IEnumerable<Shipment> shipments = new List<Shipment>();
            if (filter == "withArrivalDate")
            {
                shipments = _shipmentsServices.GetShipmentByArrivalDate(searchTerm);
            }
            if (filter == "withStatus")
            {
                shipments = _shipmentsServices.GetShipmentByStatus(searchTerm);
            }
            if (filter == "withPostalCode")
            {
                shipments = _shipmentsServices.GetShipmentByPostalCode(searchTerm);
            }
            foreach (Shipment s in shipments)
            {
                shipmentsDTOs.Add(_mapper.Map<ShipmentData>(s));
            }
            return shipmentsDTOs;
        }

        [HttpPut("update/{id}")]
        public void UpdateShipment(Guid id, ShipmentUpdateData shipmentDTO)
        {
            _shipmentsServices.UpdateShipment(id, shipmentDTO);
        }

        [HttpPost("create")]
        public void CreateShipment(ShipmentData shipmentDTO)
        {
            _shipmentsServices.CreateShipment(shipmentDTO);
        }

        [HttpDelete("delete/{id}")]
        public void DeleteShipment(Guid id)
        {
            _shipmentsServices.DeleteShipment(id);
        }

        [HttpPost("itineraries/create")]
        public void CreateItinerary(IList<Guid> shipmentsIDs)
        {
            _shipmentsServices.CreateItinerary(shipmentsIDs);
        }

        [HttpDelete("itineraries/delete/{id}")]
        public void DeleteItinerary(Guid id)
        {
            _shipmentsServices.DeleteItinerary(id);
        }

        [HttpGet("itineraries/byId/{itineraryId}")]
        public ItineraryData GetItinerary(Guid id)
        {
            return _mapper.Map<ItineraryData>(_shipmentsServices.GetItinerary(id));
        }

        [HttpGet("itineraries/all")]
        public IList<ItineraryData> GetAllItineraries()
        {
            IList<ItineraryData> itinerariesDTOs = new List<ItineraryData>();
            var itineraries = _shipmentsServices.GetAllItineraries();
            foreach (Itinerary s in itineraries)
            {
                itinerariesDTOs.Add(_mapper.Map<ItineraryData>(s));
            }
            return itinerariesDTOs;
        }

    }
}
