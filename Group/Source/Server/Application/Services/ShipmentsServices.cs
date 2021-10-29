using System;
using System.Collections.Generic;
using System.Linq;
using Server.Domain;
using Server.Application.Services.DataTransfer;
using Server.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Server.Application.Services
{
    public interface IShipmentsServices
    {
        public IEnumerable<Shipment> GetAllShipments();
        public Shipment GetShipment(Guid id);
        public Shipment GetShipmentByTrackingNumber(Guid trackingNumber);
        public IEnumerable<Shipment> GetShipmentByArrivalDate(string arrivalDate);
        public IEnumerable<Shipment> GetShipmentByStatus(string status);
        public IEnumerable<Shipment> GetShipmentByPostalCode(string postalCode); 
        public void UpdateShipment(Guid id, ShipmentData shipmentDTO);
        public void CreateShipment(ShipmentData shipmentDTO);
        public void DeleteShipment(Guid id);
    }
   
    public class ShipmentsServices : IShipmentsServices
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public ShipmentsServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unit = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<Shipment> GetAllShipments() 
        {
            var shipments = this._unit.ShipmentRepository.GetAll();
            return shipments;
        }
        public Shipment GetShipment(Guid id) 
        {
            var s = this._unit.ShipmentRepository.Get(id);
            return s;
        }
        public Shipment GetShipmentByTrackingNumber(Guid trackingNumber)
        {
            var s = this._unit.ShipmentRepository.GetByTrackingNumber(trackingNumber);
            return s;
        }
        public IEnumerable<Shipment> GetShipmentByArrivalDate(string arrivalDate)
        {
            var shipments = this._unit.ShipmentRepository.GetByArrivalDate(DateTime.Parse(arrivalDate));
            return shipments;
        }
        public IEnumerable<Shipment> GetShipmentByStatus(string status)
        {
            var shipments = this._unit.ShipmentRepository.GetByStatus(Int32.Parse(status));
            return shipments;
        }
        public IEnumerable<Shipment> GetShipmentByPostalCode(string postalCode)
        {
            var shipments = this._unit.ShipmentRepository.GetByPostalCode(Int32.Parse(postalCode));
            return shipments;
        }
        public void UpdateShipment(Guid id, ShipmentData shipmentDTO) 
        {
            try
            {
                Shipment s = this._unit.ShipmentRepository.Get(id);
                s.ArrivalDate = shipmentDTO.ArrivalDate;
                s.Weight = shipmentDTO.Weight;
                s.Precautions = shipmentDTO.Precautions;
                s.Customer = _mapper.Map<CustomerInfo>(shipmentDTO.Customer);
                s.DestinationAddress = _mapper.Map<Location>(shipmentDTO.DestinationAddress);
                ShipmentStateData shipmentStateDTO = new ShipmentStateData
                {
                    CurrentState = shipmentDTO.Status,
                    ToDate = DateTime.Now
                };
                s.addNewState(shipmentDTO.Status);
                _unit.ShipmentRepository.Update(s);
                _unit.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        public void CreateShipment(ShipmentData shipmentDTO) 
        {
            Shipment s = new Shipment();
            s.Id = Guid.NewGuid();
            s.EstimatedArrivalDate = shipmentDTO.EstimatedArrivalDate;
            s.Precautions = shipmentDTO.Precautions;
            s.Weight = shipmentDTO.Weight;
            s.Customer = _mapper.Map<CustomerInfo>(shipmentDTO.Customer);
            s.DestinationAddress = _mapper.Map<Location>(shipmentDTO.DestinationAddress);
            s.addNewState(0);
            _unit.ShipmentRepository.Add(s);
            _unit.Complete();
        }
        public void DeleteShipment(Guid id) 
        {
            var shipment = _unit.ShipmentRepository.Get(id);
            _unit.ShipmentRepository.Remove(shipment);
            _unit.Complete();
        }
        protected bool ShipmentExists(Guid id)
        {
            return _unit.ShipmentRepository.GetAll().Any(s => s.Id == id);
        }
             

    }
}
