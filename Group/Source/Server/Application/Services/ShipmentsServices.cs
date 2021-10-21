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
        public void PutShipment(Guid id, ShipmentData shipmentDTO);
        public void PostShipment(ShipmentData shipmentDTO);
        public void DeleteShipment(Guid id);
    }
   
    public class ShipmentsServices : IShipmentsServices
    {
        private readonly UnitOfWork _unit;
        public IEnumerable<Shipment> GetAllShipments() 
        {
            var shipments = _unit.ShipmentRepository.GetAll();
            return shipments;
        }
        public Shipment GetShipment(Guid id) 
        {
            var s = _unit.ShipmentRepository.Get(id);
            return s;
        }
        public void PutShipment(Guid id, ShipmentData shipmentDTO) 
        {
            try
            {
                Shipment s = _unit.ShipmentRepository.Get(id);
                s.ArrivalDate = shipmentDTO.ArrivalDate;
                s.Weight = shipmentDTO.Weight;
                s.Precautions = shipmentDTO.Precautions;
                ShipmentStateData shipmentStateDTO = new ShipmentStateData
                {
                    CurrentState = shipmentDTO.Status,
                    ToDate = DateTime.Now
                };
                s.addNewState(shipmentDTO.Status);
                _unit.Context.Entry(s).State = EntityState.Modified;
                _unit.Complete();
            }
            catch (DbUpdateConcurrencyException)
            { throw; }
            catch (Exception e) 
            { throw; }
        }
        public void PostShipment(ShipmentData shipmentDTO) 
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
        protected bool ShipmentExists(Guid id) =>
             _unit.ShipmentRepository.GetAll().Any(s => s.Id == id);

    }
}
