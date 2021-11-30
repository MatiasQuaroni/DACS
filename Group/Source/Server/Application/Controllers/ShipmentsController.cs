using System;
using System.Collections.Generic;
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
            IList<ShipmentData> shipmentsDTOs;
            var shipments = _shipmentsServices.GetAllShipments();
            shipmentsDTOs = _mapper.Map<List<ShipmentData>>(shipments);
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
            shipmentsDTOs = _mapper.Map<List<ShipmentData>>(shipments);
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
        public ItineraryData CreateItinerary(IList<Guid> shipmentsIDs)
        {
            var itinerary = _shipmentsServices.CreateItinerary(shipmentsIDs);
            return _mapper.Map<ItineraryData>(itinerary);
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
            IList<ItineraryData> itinerariesDTOs;
            var itineraries = _shipmentsServices.GetAllItineraries();
            itinerariesDTOs = _mapper.Map<List<ItineraryData>>(itineraries);
            return itinerariesDTOs;
        }

        [HttpGet("locations/byId/{locationId}")]
        public LocationData GetLocation(Guid id)
        {
            return _mapper.Map<LocationData>(_shipmentsServices.GetLocation(id));
        }

        [HttpGet("locations/all")]
        public IList<LocationData> GetAllLocations()
        {
            IList<LocationData> locationsDTOs;
            var locations = _shipmentsServices.GetAllLocations();
            locationsDTOs = _mapper.Map<List<LocationData>>(locations);
            return locationsDTOs;
        }

        [HttpGet("customers/byId/{locationId}")]
        public CustomerData GetCustomer(Guid id)
        {
            return _mapper.Map<CustomerData>(_shipmentsServices.GetCustomer(id));
        }

        [HttpGet("customers/all")]
        public IList<CustomerData> GetAllCustomers()
        {
            IList<CustomerData> customersDTOs;
            var customers = _shipmentsServices.GetAllCustomers();
            customersDTOs = _mapper.Map<List<CustomerData>>(customers);
            return customersDTOs;
        }

    }
}
