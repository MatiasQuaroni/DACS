using System;
using System.Collections.Generic;
using System.Linq;
using Server.Domain;
using Server.Application.Services.DataTransfer;
using Server.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Server.Application.Services
{
    public interface IShipmentsServices
    {
        public IEnumerable<Shipment> GetAllShipments();
        public Shipment GetShipment(Guid id);
        public void UpdateShipment(Guid id, ShipmentData shipmentDTO);
        public void CreateShipment(ShipmentData shipmentDTO);
        public void DeleteShipment(Guid id);
    }
   
    public class ShipmentsServices : IShipmentsServices
    {
        private readonly IUnitOfWork _unit;

        public ShipmentsServices(IUnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
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
        public void UpdateShipment(Guid id, ShipmentData shipmentDTO) 
        {
            try
            {
                Shipment s = this._unit.ShipmentRepository.Get(id);
                s.ArrivalDate = shipmentDTO.ArrivalDate;
                s.Weight = shipmentDTO.Weight;
                s.Precautions = shipmentDTO.Precautions;
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
            { throw; }
            catch (Exception) 
            { throw; }
        }
        public void CreateShipment(ShipmentData shipmentDTO) 
        {
            Shipment s = new Shipment();
            s.Id = Guid.NewGuid();
            s.EstimatedArrivalDate = shipmentDTO.EstimatedArrivalDate;
            s.Precautions = shipmentDTO.Precautions;
            s.Weight = shipmentDTO.Weight;
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
