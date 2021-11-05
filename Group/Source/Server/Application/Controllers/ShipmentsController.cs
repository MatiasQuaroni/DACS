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
                shipmentsDTOs.Append(_mapper.Map<ShipmentData>(s));
            }
            return shipmentsDTOs;
        }

        [HttpPut("update/{id}")]
        public void UpdateShipment(Guid id, ShipmentData shipmentDTO)
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

        [HttpDelete("itineraries/delete/{itineraryId}")]
        public void DeleteItinerary()
        {
            throw new NotImplementedException();
        }

        [HttpGet("itineraries/byId/{itineraryId}")]
        public void GetItinerary()
        {
            throw new NotImplementedException();
        }

        [HttpGet("itineraries/all")]
        public void GetAllItineraries()
        {
            throw new NotImplementedException();
        }

    }
}
