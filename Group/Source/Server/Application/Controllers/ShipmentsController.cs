using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Domain;
using Server.Application.Services.DataTransfer;
using Server.Application.Services;
using Server.Persistence.UnitOfWork;
using AutoMapper;

namespace Server.Application.Controllers
{
    [Route("Shipments")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        private readonly IShipmentsServices _shipmentsServices;
        private readonly IMapper _mapper;
        public ShipmentsController(IShipmentsServices shipmentsServices, IMapper mapper, IUnitOfWork unit) 
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
             shipmentsDTOs.Append(_mapper.Map<ShipmentData>(s));
            }
            return shipmentsDTOs;
        }

        [HttpGet("/byId/{id}")]
        public ShipmentData GetShipment(Guid id)
        {
           return _mapper.Map<ShipmentData>(_shipmentsServices.GetShipment(id));
        }

        [HttpPut("update/{id}")]
        public void PutShipment(Guid id, ShipmentData shipmentDTO)
        {
            _shipmentsServices.UpdateShipment(id, shipmentDTO);
        }

        [HttpPost("create")]
        public void PostShipment(ShipmentData shipmentDTO)
        {
            _shipmentsServices.CreateShipment(shipmentDTO);
        }

        [HttpDelete("delete/{id}")]
        public void DeleteShipment(Guid id)
        {
            _shipmentsServices.DeleteShipment(id);
        }

    }
}
